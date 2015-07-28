using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.BPM.ActivityLibrary
{
    public class ApproveBookmark : NativeActivity
    {
        /// <summary>
        /// 节点编码
        /// </summary>
        public InArgument<string> Code { get; set; }
        /// <summary>
        /// 审批人员列表
        /// </summary>
        public InArgument<List<string>> ApproverList { get; set; }
        /// <summary>
        /// 审批类型(0:串签,1:并签)
        /// </summary>
        public InArgument<int> ApproveType { get; set; }
        /// <summary>
        /// 最少的审批人数,如果没有表示需要全部审批人审批
        /// </summary>
        public InArgument<int?> MinNumberOfApprover { get; set; }

        private int? _MinNumberOfApprover;


        private int _ApproveType { get; set; }
        private List<string> Users = new List<string>();

        private int Count = 5;
        private List<Approver> _ActivityUsers = new List<Approver>();
        private List<Approver> ActivityUsers
        {
            get { return _ActivityUsers; }
        }

        private List<Approver> _ActivityApprovers = new List<Approver>();
        private List<Approver> ActivityApprovers
        {
            get { return _ActivityApprovers; }
        }
        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);
        }

        protected override bool CanInduceIdle
        {
            get { return true; }
        }

        protected override void Execute(NativeActivityContext context)
        {
            Users = context.GetValue(ApproverList);
            Count = Users.Count;
            string activityCode = Code.Get(context);
            _ApproveType = ApproveType.Get(context);
            _MinNumberOfApprover = MinNumberOfApprover.Get(context);

            for (int i = 0; i < Count; i++)
            {
                ActivityUsers.Add(new Approver
                {
                    ActivityInstanceId=context.ActivityInstanceId,
                    InstanceId=context.WorkflowInstanceId.ToString(),
                    Activity = activityCode,
                    Name = Users[i],
                    Status = 1
                });
            }

            switch (_ApproveType)
            {
                case 0://串签
                    SetApprovers(ActivityUsers.First().Name);
                    break;
                case 1://并签
                    ActivityUsers.ForEach(m => SetApprovers(m.Name));
                    break;
                default:
                    break;
            }

            string bookmarkCode = GetBookmarkCode(context);
            Console.WriteLine("创建Bookmark:{0}", bookmarkCode);
            context.CreateBookmark(bookmarkCode, new BookmarkCallback(OnBookmarkCallback), BookmarkOptions.MultipleResume);
            Console.WriteLine("当前审批人:{0}", String.Join(",",ActivityApprovers.Where(m=>m.Status==1).Select(m=>m.Name)));
        }

        private void OnBookmarkCallback(NativeActivityContext ctx, Bookmark bookmark, object state)
        {
            string user=state as String;
            var approver=ActivityApprovers.FirstOrDefault(m => m.Name == user);

            if(approver!=null)
            {
                approver.Status = 0;
            }

            if (_ApproveType==0)
            {
                var nextUser=ActivityUsers.FirstOrDefault(m => m.Status == 1);
                if(nextUser!=null)
                {
                    SetApprovers(nextUser.Name);
                }
            }

            if (!ActivityApprovers.Any(m=>m.Status==1))
            {
                ctx.RemoveBookmark(bookmark);
            }
            Console.WriteLine("当前审批人:{0}", String.Join(",", ActivityApprovers.Where(m => m.Status == 1).Select(m => m.Name)));
        }

        private string GetBookmarkCode(NativeActivityContext ctx)
        {
            string code = Code.Get(ctx);
            return String.Format("{0}${1}", code, "Approve");
        }

        private void SetApprovers(string user)
        {
            var approver = ActivityUsers.FirstOrDefault(m => m.Name == user && m.Status == 1);
            approver.Status = 0;

            ActivityApprovers.Add(new Approver
            {
                Activity = approver.Activity,
                ActivityInstanceId = approver.ActivityInstanceId,
                Folio = approver.Folio,
                Id = approver.Id,
                InstanceId = approver.InstanceId,
                Name = approver.Name,
                WorkflowCode = approver.WorkflowCode,
                Status = 1
            });

        }
    }
}
