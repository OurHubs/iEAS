using iEAS.Log;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace iEAS.Repository
{
    public class FrameworkRepository:BaseRepository
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<LogInfo> LogInfos { get; set; }

    }
}
