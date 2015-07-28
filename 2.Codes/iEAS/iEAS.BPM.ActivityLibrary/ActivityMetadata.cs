using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.BPM.ActivityLibrary
{
    public class ActivityMetadata
    {
        private List<string> _ApproveList = new List<string>();

        public string ActivityName { get; set; }

        /// <summary>
        /// 审批人
        /// </summary>
        public string Approvers { get; set; }

        /// <summary>
        /// 申请人列表
        /// </summary>
        public List<string> ApproverList
        {
            get { return _ApproveList; }
            set { _ApproveList = value; }
        }

        /// <summary>
        /// 审批类型
        /// </summary>
        public ApproveType ApproveType { get; set; }
    }
}
