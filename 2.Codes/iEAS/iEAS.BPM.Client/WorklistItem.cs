using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.BPM.Client
{
    [DataContract]
    public class WorklistItem
    {
        internal IBPMService Service { get; set; }
        [DataMember]
        public string SN { get; set; }
        [DataMember]
        public string Folio { get; set; }
        [DataMember]
        public ProcessInstance ProcessInstance { get; set; }
        [DataMember]
        public ActivityInstance ActivityInstance { get; set; }
        [DataMember]
        public string Approver { get; set; }
        [DataMember]
        public string TargetApprover { get; set; }
        public void Exectue()
        {
            Service.ExecuteWorklistItem(this);
        }
    }
}
