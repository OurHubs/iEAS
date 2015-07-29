using iEAS.BPM.Repository.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.BPM
{
    public class BPMRepository : DbContext
    {
        public BPMRepository()
            : base("iBPMConn")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProcessMapping());
            modelBuilder.Configurations.Add(new ActivityMapping());
            modelBuilder.Configurations.Add(new ProcessInstanceMapping());
            modelBuilder.Configurations.Add(new ActivityInstanceMapping());
            modelBuilder.Configurations.Add(new WorklistItemMapping());
            modelBuilder.Configurations.Add(new WorklistItemApproverMapping());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Process> Process { get; set; }
        public DbSet<Activity> Activity { get; set; }
        public DbSet<ProcessInstance> ProcessInstance { get; set; }
        public DbSet<ActivityInstance> ActivityInstance { get; set; }
        public DbSet<WorklistItem> WorklistItem { get; set; }
        public DbSet<WorklistItemApprover> WorklistItemApprover { get; set; }
    }
}
