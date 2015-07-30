using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.BPM
{
    public class DataField
    {
        public int Id { get; set; }

        public int ProcessId { get; set; }
        public int ActivityId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string DefaultValue { get; set; }
    }
}
