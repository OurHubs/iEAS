using iEAS.Account;
using iEAS.BaseData;
using iEAS.Log;
using iEAS.Module;
using iEAS.Repository.Mapping.Account;
using iEAS.Repository.Mapping.BaseData;
using iEAS.Repository.Mapping.Module;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
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
            
            modelBuilder.Configurations.Add(new ModuleInfoMapping());
            modelBuilder.Configurations.Add(new FeatureMapping());
            modelBuilder.Configurations.Add(new PortalInfoMapping());
            modelBuilder.Configurations.Add(new MenuMapping());
            modelBuilder.Configurations.Add(new ChannelMapping());

            modelBuilder.Configurations.Add(new PermissionMapping());
            modelBuilder.Configurations.Add(new UserMapping());
            modelBuilder.Configurations.Add(new RoleMapping());

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();//移除复数表名的契约
            modelBuilder.Conventions.Remove<IncludeMetadataConvention>();//防止黑幕交易 要不然每次都要访问 EdmMetadata这个表
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<BaseDataType> BaseDataTypes { get; set; }
        public DbSet<BaseDataItem> BaseDataItems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<ModuleInfo> ModuleInfos { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<PortalInfo> PortalInfos { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Channel> Channels { get; set; }
    }
}
