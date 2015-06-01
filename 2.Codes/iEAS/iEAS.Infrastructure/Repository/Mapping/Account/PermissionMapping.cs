using iEAS.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.Repository.Mapping.Account
{
    public class PermissionMapping:IdentityEntityMapping<Permission>
    {
        public PermissionMapping()
        {
            this.ToTable("PERMISSION");

            this.Property(m => m.OwnerID, "OWNER_ID", 50);
            this.Property(m => m.OwnerType, "OWNER_TYPE", 50);
            this.Property(m => m.ResouceID, "RESOURCE_ID", 100);
            this.Property(m => m.ResourceType, "RESOURCE_TYPE", 50);
        }
    }
}
