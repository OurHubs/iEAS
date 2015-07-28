using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.BPM.ActivityLibrary
{
    public class Approver
    {
        /// <summary>
        /// ID
        /// </summary>
        public Guid Id { get; set; }

        public string WorkflowCode { get; set; }

        public string InstanceId { get; set; }

        public string Folio { get; set; }
        /// <summary>
        /// 节点
        /// </summary>
        public string Activity { get; set; }

        public string ActivityInstanceId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 1:有效，0：无效
        /// </summary>
        public int Status { get; set; }
    }
}
