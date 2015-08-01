using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.BPM.Client
{
    [DataContract]
    public class Activity
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 节点名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 目录操作人类型
        /// 0:按指定审批人审批,1:按Role审批,2：按传入的DataField审批,3:按ReportLine进行审批
        /// </summary>
        public DestinationType DestinationType { get; set; }
        /// <summary>
        /// 目录操作人
        /// </summary>
        public string Destination { get; set; }
    }
}
