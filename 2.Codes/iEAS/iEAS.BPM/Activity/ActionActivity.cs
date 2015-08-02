using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.BPM
{
    public class ActionActivity : NativeActivity
    {
        private string ActionBookmark
        {
            get { return this.DisplayName + "$Action"; }
        }

        protected override bool CanInduceIdle
        {
            get
            {
                return true;
            }
        }

        protected override void Execute(NativeActivityContext context)
        {
            /****
               1、分配人员
               2、创建审批Bookmark
               3、异常处理，如果发现异常就创建异常Bookmark
             ***/
            #region 添加审批人
            using (var req = new BPMRepository())
            {
                var instance = req.ProcessInstance.FirstOrDefault(m => m.ApplicationId == context.WorkflowInstanceId);

                var activity = req.Activity.FirstOrDefault(m => m.Process.Id == instance.ProcessId && m.Name==this.DisplayName);
                var actInst = new ActivityInstance
                {
                    ActivityId = activity.Id,
                    ProcessInstanceId = instance.Id
                };
                if (activity.DestinationType == DestinationType.User)
                {
                    string[] users = activity.Destination.Split(';');
                    foreach (var u in users)
                    {
                        ActivityInstanceDestination aid = new ActivityInstanceDestination
                        {
                            ActivityInstance = actInst,
                            Approver = u,
                            TargetApprover = u,
                            Destination = activity.Destination,
                            DestinationType = activity.DestinationType,
                            ProcessInstanceId = instance.Id,
                            Deleted = false
                        };
                        actInst.Destinations.Add(aid);
                    }
                }
                req.ActivityInstance.Add(actInst);
                req.SaveChanges();
            }
            #endregion

            #region 创建审批Bookmark
            Console.WriteLine("创建Bookmark");
            context.CreateBookmark(ActionBookmark, new BookmarkCallback(OnActionCallBack), BookmarkOptions.MultipleResume);
            Console.WriteLine("BookMark:执行完成");
            #endregion
           
        }

        private void OnActionCallBack(NativeActivityContext context, Bookmark mark, object state)
        {
            ActivityArguments args = state as ActivityArguments;
            if (args == null)
                return;

            using (var req = new BPMRepository())
            {
                var instance = req.ProcessInstance.FirstOrDefault(m => m.ApplicationId == context.WorkflowInstanceId);
                var actInst = req.ActivityInstance.FirstOrDefault(m => m.ProcessInstanceId == instance.Id && m.Activity.Name == this.DisplayName);

                actInst.Destinations.FirstOrDefault(m => m.Approver == args.Approver).Deleted = true;
                if (actInst.Destinations.All(m => m.Deleted))
                {
                    context.RemoveBookmark(mark);
                    req.ActivityInstance.Remove(actInst);
                    Console.WriteLine("BookMark：Action：被移除");
                }
                else
                {
                    Console.WriteLine("剩余的审批人:");
                    foreach(var dest in actInst.Destinations.Where(m=>!m.Deleted))
                    {
                        Console.WriteLine(dest.Approver);
                    }
                }
                req.SaveChanges();
            }
        }
    }
}
