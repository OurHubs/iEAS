using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.BPM.Repository.Mapping
{
    public class ActivityInstanceMapping : EntityTypeConfiguration<ActivityInstance>
    {
        public ActivityInstanceMapping()
        {
            this.ToTable("ActivityInstance");
            this.HasKey(m => m.Id);
            this.HasRequired(m => m.Activity).WithMany().HasForeignKey(m => m.ActivityId).WillCascadeOnDelete(false);
            this.HasRequired(m => m.ProcessInstance).WithMany().HasForeignKey(m => m.ProcessInstanceId).WillCascadeOnDelete();
        }
    }
}
