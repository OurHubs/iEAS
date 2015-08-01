using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.BPM
{
    /// <summary>
    /// 节点实例
    /// </summary>
    public class ActivityInstance
    {
        private List<ActivityInstanceDestination> _Destinations = new List<ActivityInstanceDestination>();

        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 节点Id
        /// </summary>
        public int ActivityId { get; set; }
        /// <summary>
        /// 流程实例Id
        /// </summary>
        public int ProcessInstanceId { get; set; }
        /// <summary>
        /// 节点名称
        /// </summary>
        public string ActivityName
        {
            get { return Activity.Name; }
        }
        /// <summary>
        /// 节点信息
        /// </summary>
        public virtual Activity Activity { get; set; }
        /// <summary>
        /// 流程实例
        /// </summary>
        public virtual ProcessInstance ProcessInstance { get; set; }
        /// <summary>
        /// 目标操作人
        /// </summary>
        public virtual List<ActivityInstanceDestination> Destinations
        {
            get { return _Destinations; }
            set { _Destinations = value; }
        }
    }
}
