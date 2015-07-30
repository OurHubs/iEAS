using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.BPM
{
    public class ProcessInstance
    {
        public int Id { get; set; }
        /// <summary>
        /// 流程Id
        /// </summary>
        public int ProcessId { get; set; }
        /// <summary>
        /// Folio
        /// </summary>
        public string Folio { get; set; }
        /// <summary>
        /// 流程发起人
        /// </summary>
        public string Originator { get; set; }
        /// <summary>
        /// 流程信息
        /// </summary>
        public virtual Process Process { get; set; }
        /// <summary>
        /// 流程活动的节点实例
        /// </summary>
        public virtual List<ActivityInstance> Activities { get; set; }
    }
}
