using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.BPM
{
    public class Worklist:System.Collections.ObjectModel.ReadOnlyCollection<WorklistItem>
    {
        public Worklist(IList<WorklistItem> items)
            :base(items)
        {
        }
    }
}
