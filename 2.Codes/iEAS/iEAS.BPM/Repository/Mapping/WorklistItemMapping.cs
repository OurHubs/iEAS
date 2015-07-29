using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.BPM.Repository.Mapping
{
    public class WorklistItemMapping : EntityTypeConfiguration<WorklistItem>
    {
        public WorklistItemMapping()
        {
            this.HasKey(m => m.Id);

            this.HasRequired(m => m.ProcessInstance).WithMany().HasForeignKey(m => m.ProcessInstanceId).WillCascadeOnDelete(false);
            this.HasRequired(m => m.ActivityInstance).WithMany().HasForeignKey(m => m.ActivityInstanceId).WillCascadeOnDelete();
        }
    }
}
