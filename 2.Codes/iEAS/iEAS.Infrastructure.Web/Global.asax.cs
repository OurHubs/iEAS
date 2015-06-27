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


namespace iEAS.Infrastructure.Web
{
    public class Global : iEASGlobal
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.MapPageRoute("Home", "", "~/Portal/TemplateEngine/Home.aspx");
            RouteTable.Routes.MapPageRoute("Channel", "Channel/{ChannelID}", "~/Portal/TemplateEngine/Channel.aspx");
            RouteTable.Routes.MapPageRoute("Detail", "Detail/{RecordID}", "~/Portal/TemplateEngine/Channel.aspx");
        }

        protected override void RegisterComponents(ContainerBuilder builder)
        {
            builder.RegisterType<HttpCacheProvider>().As<ICacheProvider>().InstancePerRequest();
            builder.RegisterType<DomainService>().As<IDomainService>();

            builder.RegisterType<FrameworkRepository>().AsSelf();
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
            // builder.RegisterType<ILogger>().As<Log4netLogger>();

        }
    }

    public class CurrentUserProvider : ICurrentUserProvider
    {

        public IUserInfo GetCurrentUserInfo()
        {
            return new User();
        }
    }
}