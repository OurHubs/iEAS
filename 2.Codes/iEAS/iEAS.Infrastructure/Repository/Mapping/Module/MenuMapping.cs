using iEAS.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.Repository.Mapping.Module
{
    class MenuMapping : IdentityEntityMapping<Menu>
    {
        public MenuMapping()
        {
            this.ToTable("MENU");

            this.Property(m => m.Name, "NAME", 50);
            this.Property(m => m.Code, "CODE", 50);
            this.Property(m => m.Desc, "DESC", 200);
            this.Property(m => m.PortalID, "PORTAL_ID");
            this.Property(m => m.ParentID, "PARENT_ID");
            this.Property(m => m.Url, "URL", 255);
            this.Property(m => m.Sort, "SORT");

            this.HasRequired(m => m.Portal).WithMany(m => m.Menus).HasForeignKey(m => m.PortalID);
            this.HasOptional(m => m.Parent).WithMany(m => m.Children).HasForeignKey(m => m.ParentID);
        }
    }
}
