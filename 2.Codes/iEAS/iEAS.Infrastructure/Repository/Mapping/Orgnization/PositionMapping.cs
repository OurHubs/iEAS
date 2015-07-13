using iEAS.Orgnization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.Repository.Mapping.Orgnization
{
    public class PositionMapping : IdentityEntityMapping<Position>
    {
        public PositionMapping()
        {
            this.ToTable("POSITION");

            this.Property(m => m.Name, "NAME",50);
            this.Property(m => m.Code, "Code", 50);
            this.Property(m => m.Desc, "DESC",500);
            this.Property(m => m.Level, "LEVEL",50);
        }
    }
}
