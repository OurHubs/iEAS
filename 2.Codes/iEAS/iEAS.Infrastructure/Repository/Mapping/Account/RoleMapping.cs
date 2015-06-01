using iEAS.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.Repository.Mapping.Account
{
    public class RoleMapping:IdentityEntityMapping<Role>
    {
        public RoleMapping()
        {
            this.ToTable("ROLE");

            this.Property(m => m.Name, "NAME", 50);
            this.Property(m => m.Code, "CODE", 50);
            this.Property(m => m.Desc, "DESC", 500);
        }
    }
}
