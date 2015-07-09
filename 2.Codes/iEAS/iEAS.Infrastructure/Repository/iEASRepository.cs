using iEAS.Account;
using iEAS.BaseData;
using iEAS.Log;
using iEAS.Module;
using iEAS.Orgnization;
using iEAS.Repository.Mapping.Account;
using iEAS.Repository.Mapping.BaseData;
using iEAS.Repository.Mapping.Module;
using iEAS.Repository.Mapping.Orgnization;
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

            #region 组织机构
            modelBuilder.Configurations.Add(new CompanyMapping());
            modelBuilder.Configurations.Add(new DepartmentMapping());
            modelBuilder.Configurations.Add(new EmergencyContactMapping());
            modelBuilder.Configurations.Add(new EmployeeMapping());
            modelBuilder.Configurations.Add(new EmployeePositionMapping());
            modelBuilder.Configurations.Add(new EmployeeTitleMapping());
            modelBuilder.Configurations.Add(new PositionMapping());
            modelBuilder.Configurations.Add(new ReportLineMapping());
            modelBuilder.Configurations.Add(new TitleMapping());
            #endregion

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();//移除复数表名的契约
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
        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<EmergencyContact> EmergencyContacts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeePosition> EmployeePositions { get; set; }
        public DbSet<EmployeeTitle> EmployeeTitles { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<ReportLine> ReportLines { get; set; }
        public DbSet<Title> Titles { get; set; }
    }
}
