using iEAS.BaseData;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.Repository.Mapping.BaseData
{
    public class BaseDataTypeMapping : IdentityEntityMapping<BaseDataType>
    {
        public BaseDataTypeMapping()
        {
            this.ToTable("BASE_DATA_TYPE");
            this.Property(m => m.Name, "NAME", 50);
            this.Property(m => m.Code, "CODE", 50);
            this.Property(m => m.Desc, "DESC", 500);
        }
    }
}
