using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.BPM
{
    public class ProcessInstance
    {
        public Guid Id { get; set; }
        public string Folio { get; set; }
        public string Originator { get; set; }
        public Guid ProcessId { get; set; }
        public virtual Process Process { get; set; }
        public virtual List<ActivityInstance> Activities { get; set; }
    }
}
