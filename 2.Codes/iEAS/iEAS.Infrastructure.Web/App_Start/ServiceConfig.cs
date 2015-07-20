using Autofac;
using iEAS.BaseData;
using iEAS.Caching;
using iEAS.Repository;
using iEAS.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using iEAS.Module;
using iEAS.Account;
using iEAS.Framework.Log;
using System.Web.Routing;
using System.Data.Entity;
using iEAS.Orgnization;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Http;


namespace iEAS.Infrastructure.Web
{
    public class ServiceConfig
    {
        public static void Register(ContainerBuilder builder)
        {
            builder.RegisterType<HttpCacheProvider>().As<ICacheProvider>().InstancePerRequest();
            builder.RegisterType<DomainService>().As<IDomainService>();

            builder.RegisterType<iEASRepository>().AsSelf();

            builder.RegisterType<CurrentUserProvider>().As<ICurrentUserProvider>();

            builder.RegisterType<BaseDataTypeService>().As<IBaseDataTypeService>();
            builder.RegisterType<BaseDataItemService>().As<IBaseDataItemService>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<RoleService>().As<IRoleService>();
            builder.RegisterType<PermissionService>().As<IPermissionService>();
            builder.RegisterType<ModuleService>().As<IModuleService>();
            builder.RegisterType<FeatureService>().As<IFeatureService>();
            builder.RegisterType<PortalService>().As<IPortalService>();
            builder.RegisterType<MenuService>().As<IMenuService>();
            builder.RegisterType<ChannelService>().As<IChannelService>();
            builder.RegisterType<DesptopUCService>().As<IDesptopUCService>();
            builder.RegisterType<UserDesptopUCService>().As<IUserDesptopUCService>();


            builder.RegisterType<CompanyService>().As<ICompanyService>();
            builder.RegisterType<DepartmentService>().As<IDepartmentService>();
            builder.RegisterType<TitleService>().As<ITitleService>();
            builder.RegisterType<PositionService>().As<IPositionService>();
            builder.RegisterType<EmployeeService>().As<IEmployeeService>();
            builder.RegisterType<EmployeePositionService>().As<IEmployeePositionService>();
        }
    }
}