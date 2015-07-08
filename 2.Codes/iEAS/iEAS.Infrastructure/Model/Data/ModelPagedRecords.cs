using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.Model.Data
{
    public class ModelPagedRecords:List<IReadOnlyDictionary<string,object>>
    {
        public int RecordCount { get; set; }
    }
}
