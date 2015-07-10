using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iEAS.Module;

namespace iEAS.Repository.Mapping.Module
{
    public class UserDesptopUCMapping : EntityMapping<UserDesptopUC>
    {
        public UserDesptopUCMapping()
        {
            this.ToTable("USER_DESTOPUC");
            this.Property(m => m.UserGUI, "USERGUI", 50);
            this.Property(m => m.DestopUCType, "DESTOPUCTYPE", 50);
            this.Property(m => m.UCCodes, "UCCODES", 200);
        }
    }
}
