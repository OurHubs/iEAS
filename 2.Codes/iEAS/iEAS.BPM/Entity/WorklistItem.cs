using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.BPM
{
    public class WorklistItem
    {
        /// <summary>
        /// 流程实例
        /// </summary>
        public ProcessInstance ProcessInstance { get; set; }
        /// <summary>
        /// 节点实例
        /// </summary>
        public ActivityInstance ActivityInstance { get; set; }
        public ActivityInstanceDestination ActivityInstanceDestination { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Folio { get; set; }
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

        public void Execute(Dictionary<string,object> data)
        {
            using (var req = new BPMRepository())
            {
                var actInst = req.ActivityInstanceDestination.FirstOrDefault(m=>m.ProcessInstanceId==ProcessInstance.Id && m.Approver==this.Approver);
                actInst.Deleted = true;
                req.SaveChanges();
                WorkflowEngine.Current.ExecuteFlow(ProcessInstance.ApplicationId, actInst.ActivityInstance.Activity.Name);
            }
           
          
        }
    }
}
