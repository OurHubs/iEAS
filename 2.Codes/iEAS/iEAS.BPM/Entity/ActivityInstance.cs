using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.BPM
{
    public class ActivityInstance
    {
        public Guid Id { get; set; }
        public Guid ActivityId { get; set; }
        public virtual Activity Activity { get; set; }
        public Guid ProcessInstanceId { get; set; }
        public virtual ProcessInstance ProcessInstance { get; set; }
    }
}
