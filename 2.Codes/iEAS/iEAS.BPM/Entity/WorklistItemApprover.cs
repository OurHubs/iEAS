using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.BPM
{
    public class WorklistItemApprover
    {
        public Guid Id { get; set; }

        public Guid WorklistItemId { get; set; }

        public string Name { get; set; }

        public virtual WorklistItem WorklistItem { get; set; }
    }
}
