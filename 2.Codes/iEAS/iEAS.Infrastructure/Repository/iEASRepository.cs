﻿using iEAS.Account;
using iEAS.BaseData;
using iEAS.Log;
using iEAS.Module;
using iEAS.Repository.Mapping.Account;
using iEAS.Repository.Mapping.BaseData;
using iEAS.Repository.Mapping.Module;
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
            modelBuilder.Configurations.Add(new ModuleInfoMapping());
            modelBuilder.Configurations.Add(new FeatureMapping());
            modelBuilder.Configurations.Add(new PortalInfoMapping());
            modelBuilder.Configurations.Add(new MenuMapping());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<BaseDataType> BaseDataTypes { get; set; }
        public DbSet<BaseDataItem> BaseDataItems { get; set; }
        //public DbSet<Permission> Permissions { get; set; }
        public DbSet<ModuleInfo> ModuleInfos { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<PortalInfo> PortalInfos { get; set; }
        public DbSet<Menu> Menus { get; set; }
    }
}
