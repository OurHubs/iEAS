using iEAS.Orgnization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.Repository.Mapping.Orgnization
{
    public class TitleMapping : IdentityEntityMapping<Title>
    {
        public TitleMapping()
        {
            this.ToTable("TITLE");

            this.Property(m => m.Name, "NAME", 50);
            this.Property(m => m.Code, "CODE", 50);
            this.Property(m => m.Level, "LEVEL");
            this.Property(m => m.Desc, "DESC", 500);
        }
    }
}
