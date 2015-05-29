using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.BaseData
{
    public class BaseDataItem:IdentityEntity
    {
        public int TypeID { get; set; }

        public int? ParentID { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public string Desc { get; set; }

        public virtual BaseDataType Type { get; set; }

        public virtual BaseDataItem Parent { get; set; }

        public virtual List<BaseDataItem> Items { get; set; }
    }
}
