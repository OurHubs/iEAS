using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.BPM.Client
{
    [DataContract]
    public class ProcessInstance
    {
        private IBPMService _BPMService;

        internal IBPMService BPMService
        {
            get { return _BPMService; }
            set { _BPMService = value; }
        }

        private int _State;
        #region 属性
        [DataMember]
        public int Id { get; set; }
        /// <summary>
        /// Folio
        /// </summary>
        [DataMember]
        public string Folio { get; set; }
        /// <summary>
        /// 流程发起人
        /// </summary>
        [DataMember]
        public string Originator { get; set; }
        /// <summary>
        /// 完成状态
        /// -1:未发起，0：运转中,1：已完成,2:取消,3:终止,4:异常
        /// </summary>
        [DataMember]
        public int State
        {
            get { return _State; }
            set { _State = value; }
        }
        /// <summary>
        /// 应用程序Id
        /// </summary>
        [DataMember]
        public Guid ApplicationId { get; set; }
        /// <summary>
        /// 流程信息
        /// </summary>
        [DataMember]
        public Process Process { get; set; }
        /// <summary>
        /// 流程活动的节点实例
        /// </summary>
        [DataMember]
        public List<ActivityInstance> Activities { get; internal set; }
        #endregion

        public void Submit()
        {
            var newInst=_BPMService.SubmitProcessInstance(this);
            this.State = newInst.State;
        }
    }
}
