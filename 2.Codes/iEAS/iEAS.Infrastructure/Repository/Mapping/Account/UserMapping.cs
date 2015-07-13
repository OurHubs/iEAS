using iEAS.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.Repository.Mapping.Account
{
    public class UserMapping : IdentityEntityMapping<User>
    {
        public UserMapping()
        {
            this.ToTable("USER_INFO");

            this.Property(m => m.LoginName, "LOGIN_NAME", 50);
            this.Property(m => m.Password, "PASSWORD", 50);
            this.Property(m => m.Name, "NAME", 50);
            this.Property(m => m.Nick, "NICK", 50);
            this.Property(m => m.Gender, "GENDER");
            this.Property(m => m.Birthday, "BIRTHDAY");
            this.Property(m => m.Telephone, "TELEPHONE", 50);
            this.Property(m => m.Email, "EMAIL", 50);
            this.Property(m => m.HomeZip, "HOME_ZIP", 50);
            this.Property(m => m.HomeAddress, "HOME_ADDRESS", 200);
            this.Property(m => m.WorkZip, "WORK_ZIP", 50);
            this.Property(m => m.WorkAddress, "WORK_ADDRESS", 200);
            this.Property(m => m.EncryptionType, "ENCRYPTION_TYPE");
            this.Property(m => m.Source, "SOURCE", 50);

            this.HasMany(m => m.Roles).WithMany().Map(c =>
            {
                c.ToTable("USER_ROLE_REL");
                c.MapLeftKey("USER_ID");
                c.MapRightKey("ROLE_ID");
            });
        }
    }
}
