using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.BPM.Repository.Mapping
{
    public class WorklistItemApproverMapping : EntityTypeConfiguration<WorklistItemApprover>
    {
        public WorklistItemApproverMapping()
        {
            this.HasKey(m => m.Id);

            this.HasRequired(m => m.WorklistItem).WithMany().HasForeignKey(m => m.WorklistItemId).WillCascadeOnDelete();
        }
    }
}
