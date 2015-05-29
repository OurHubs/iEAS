using iEAS.BaseData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.Repository.Mapping.BaseData
{
    public class BaseDataItemMapping : IdentityEntityMapping<BaseDataItem>
    {
        public BaseDataItemMapping()
        {
            this.ToTable("BASE_DATA_ITEM");
            this.Property(m => m.Name).HasColumnType("nvarchar").HasMaxLength(500);
            this.Property(m => m.Value).HasColumnType("nvarchar").HasMaxLength(500);
            this.Property(m => m.Desc).HasColumnType("nvarchar").HasMaxLength(500);
            this.HasRequired(m => m.Type).WithMany().HasForeignKey(m => m.TypeID);
            this.HasMany(m => m.Items).WithOptional().HasForeignKey(m => m.ParentID);
        }
    }
}
