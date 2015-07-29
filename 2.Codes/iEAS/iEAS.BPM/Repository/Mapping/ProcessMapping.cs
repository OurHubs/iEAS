using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.BPM.Repository.Mapping
{
    public class ProcessMapping : EntityTypeConfiguration<Process>
    {
        public ProcessMapping()
        {
            this.HasKey(m => m.Id);

            //this.HasMany(m => m.Activities).WithRequired(m => m.Process).HasForeignKey(m => m.ProcessId).WillCascadeOnDelete();
        }
    }
}
