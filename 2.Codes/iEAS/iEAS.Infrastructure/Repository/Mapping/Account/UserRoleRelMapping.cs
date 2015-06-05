using iEAS.Account;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.Repository.Mapping.Account
{
    public class UserRoleRelMapping : EntityTypeConfiguration<UserRoleRel>
    {
        public UserRoleRelMapping()
        {
            this.ToTable("USER_ROLE_REL");
            this.HasKey(m => m.UserID).HasKey(m => m.RoleID);

            this.Property(m => m.RoleID).HasColumnName("ROLE_ID");
            this.Property(m => m.UserID).HasColumnName("USER_ID");
        }
    }
}
