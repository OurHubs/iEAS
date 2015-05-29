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
            this.Property(m => m.Name, "NAME",500);
            this.Property(m => m.Value, "VALUE",500);
            this.Property(m => m.Desc, "DESC", 500);

            this.Property(m => m.TypeID, "TYPE_ID");
            this.Property(m => m.ParentID, "PARENT_ID");
            this.HasRequired(m => m.Type).WithMany(m=>m.Items).HasForeignKey(m => m.TypeID).WillCascadeOnDelete(false);
            this.HasMany(m => m.Items).WithOptional(m=>m.Parent).HasForeignKey(m => m.ParentID).WillCascadeOnDelete(false);
        }
    }
}
