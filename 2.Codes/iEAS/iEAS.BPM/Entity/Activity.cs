using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.BPM
{
    public class Activity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid ProcessId { get; set; }

        public virtual Process Process { get; set; }
    }
}
