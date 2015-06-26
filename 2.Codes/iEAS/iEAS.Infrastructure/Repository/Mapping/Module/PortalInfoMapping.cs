using iEAS.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.Repository.Mapping.Module
{
    class PortalInfoMapping: IdentityEntityMapping<PortalInfo>
    {
        public PortalInfoMapping()
        {
            this.ToTable("PORTAL");

            this.Property(m => m.Name, "NAME", 50);
            this.Property(m => m.Code, "CODE", 50);
            this.Property(m => m.Desc, "DESC", 200);
            this.Property(m => m.Sort, "SORT");
        }
    }
}
