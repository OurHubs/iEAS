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
    public class Global : iEASGlobal
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);
            Database.SetInitializer<iEASRepository>(null);
        }

        protected override void RegisterComponents(ContainerBuilder builder)
        {
            ServiceConfig.Register(builder);
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