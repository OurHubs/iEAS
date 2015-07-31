using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.BPM
{
    /// <summary>
    /// 节点处理人
    /// </summary>
    public class ActivityInstanceDestination
    {
        /// <summary>
        /// 节点目标对象Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 节点实例Id
        /// </summary>
        public int ActivityInstanceId { get; set; }
        /// <summary>
        /// 流程实例Id
        /// </summary>
        public int ProcessInstanceId { get; set; }
        /// <summary>
        /// 目标对象类型
        /// </summary>
        public DestinationType DestinationType { get; set; }
        /// <summary>
        /// 目标对像
        /// </summary>
        public string Destination { get; set; }
        /// <summary>
        /// 目标审批人
        /// </summary>
        public string TargetApprover { get; set; }
        /// <summary>
        /// 当前审批人
        /// </summary>
        public string Approver { get; set; }
        /// <summary>
        /// 是否被删除
        /// </summary>
        public bool Deleted { get; set; }
        /// <summary>
        /// 节点实例
        /// </summary>
        public virtual ActivityInstance ActivityInstance { get; set; }
        /// <summary>
        /// 流程实例
        /// </summary>
        public virtual ProcessInstance ProcessInstance { get; set; }
    }
}
