using iEAS.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.Repository.Mapping.Module
{
    public class FeatureMapping : IdentityEntityMapping<Feature>
    {
        public FeatureMapping()
        {
            this.ToTable("FEATURE");

            this.Property(m => m.Name,"NAME",50);
            this.Property(m => m.Code,"CODE",50);
            this.Property(m => m.Desc, "DESC", 200);
            this.Property(m => m.ModuleID, "MODULE_ID");
            this.Property(m => m.ParentID, "PARENT_ID");

            this.HasRequired(m => m.Module).WithMany(m => m.Features).HasForeignKey(m => m.ModuleID);
            this.HasOptional(m => m.Parent).WithMany(m => m.Children).HasForeignKey(m => m.ParentID);
        }
    }
}
