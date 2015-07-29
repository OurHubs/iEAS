using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.BPM
{
    public class Process
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public virtual List<Activity> Activities { get; set; }
    }
}
