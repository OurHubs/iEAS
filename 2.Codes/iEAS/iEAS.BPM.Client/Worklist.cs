using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.BPM.Client
{
    [DataContract]
    public class Worklist:ReadOnlyCollection<WorklistItem>
    {
        public Worklist(IList<WorklistItem> items)
            :base(items)
        {
        }
    }
}
