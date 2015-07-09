using iEAS.Orgnization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.Repository.Mapping.Orgnization
{
    public class CompanyMapping : IdentityEntityMapping<Company>
    {
        public CompanyMapping()
        {
            this.ToTable("COMPANY");

            this.Property(m => m.Name, "NAME", 50);
            this.Property(m => m.Code, "CODE", 50);
            this.Property(m => m.Desc, "DESC", 200);
            this.Property(m => m.Address, "ADDRESS", 200);
            this.Property(m => m.WebUrl, "WEB_URL", 200);
        }
    }
}
