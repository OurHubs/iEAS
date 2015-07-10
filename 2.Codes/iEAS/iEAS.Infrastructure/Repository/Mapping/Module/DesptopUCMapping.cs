using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iEAS.Module;

namespace iEAS.Repository.Mapping.Module
{
    public class DesptopUCMapping : EntityMapping<DesptopUC>
    {
        public DesptopUCMapping()
        {
            this.ToTable("DESPTOPUC");
            this.Property(m => m.Name, "NAME", 50);
            this.Property(m => m.Code, "CODE", 50);
            this.Property(m => m.Desc, "DESC", 200);
        }

    }
}
