using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.BPM.Repository.Mapping
{
    public class ProcessInstanceMapping : EntityTypeConfiguration<ProcessInstance>
    {
        public ProcessInstanceMapping()
        {
            this.ToTable("ProcessInstance");

            this.HasKey(m => m.Id);
            this.Property(m => m.ProcessId);
            this.HasRequired(m => m.Process).WithMany().HasForeignKey(m => m.ProcessId).WillCascadeOnDelete(false);
            this.HasMany(m => m.Activities).WithRequired(m => m.ProcessInstance).HasForeignKey(m => m.ProcessInstanceId).WillCascadeOnDelete();
        }
    }
}
