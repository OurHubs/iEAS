using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.BPM.Repository.Mapping
{
    public class ActivityMapping : EntityTypeConfiguration<Activity>
    {
        public ActivityMapping()
        {
            this.HasKey(m => m.Id);
            this.HasRequired(m => m.Process).WithMany(m => m.Activities).HasForeignKey(m => m.ProcessId).WillCascadeOnDelete();
        }
    }
}