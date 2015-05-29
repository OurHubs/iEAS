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
            this.Property(m => m.Name).HasColumnType("nvarchar").HasMaxLength(50);
            this.Property(m => m.Code).HasColumnType("nvarchar").HasMaxLength(50);
            this.Property(m => m.Desc).HasColumnType("nvarchar").HasMaxLength(500);
            this.HasMany(m => m.Items).WithRequired();
        }
    }
}
