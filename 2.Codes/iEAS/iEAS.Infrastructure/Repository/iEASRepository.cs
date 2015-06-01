using iEAS.Account;
using iEAS.BaseData;
using iEAS.Log;
using iEAS.Repository.Mapping.Account;
using iEAS.Repository.Mapping.BaseData;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.Repository
{
    public class iEASRepository:BaseRepository
    {
        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BaseDataTypeMapping());
            modelBuilder.Configurations.Add(new BaseDataItemMapping());
            //modelBuilder.Configurations.Add(new PermissionMapping());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<BaseDataType> BaseDataTypes { get; set; }
        public DbSet<BaseDataItem> BaseDataItems { get; set; }
        //public DbSet<Permission> Permissions { get; set; }
    }
}
