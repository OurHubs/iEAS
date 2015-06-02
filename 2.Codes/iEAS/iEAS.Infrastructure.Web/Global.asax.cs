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


namespace iEAS.Infrastructure.Web
{
    public class Global : iEASGlobal
    {
        protected void Application_Start(object sender, EventArgs e)
        {
        }

        protected override void RegisterComponents(ContainerBuilder builder)
        {
            builder.RegisterType<HttpCacheProvider>().As<ICacheProvider>().InstancePerRequest();
            builder.RegisterGeneric(typeof(DomainService<,>)).As(typeof(IDomainService<,>));


            builder.RegisterType<FrameworkRepository>().AsSelf();
            builder.RegisterType<iEASRepository>().AsSelf();
            builder.RegisterType<BaseDataTypeService>().As<IBaseDataTypeService>();
            builder.RegisterType<BaseDataItemService>().As<IBaseDataItemService>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<RoleService>().As<IRoleService>();
            builder.RegisterType<PermissionService>().As<IPermissionService>();
            builder.RegisterType<PortalService>().As<IPortalService>();
        }
    }
}