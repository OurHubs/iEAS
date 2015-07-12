﻿using Autofac;
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


namespace iEAS.Infrastructure.Web
{
    public class Global : iEASGlobal
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Database.SetInitializer<iEASRepository>(null);

            RouteTable.Routes.MapPageRoute("Home", "", "~/Portal/TemplateEngine/Home.aspx");
            RouteValueDictionary defChannel=new RouteValueDictionary();
            defChannel.Add("PageIndex",1);
            RouteTable.Routes.MapPageRoute("ChannelList", "Channel/{ChannelID}_{PageIndex}", "~/Portal/TemplateEngine/Channel.aspx",false,defChannel);
            RouteTable.Routes.MapPageRoute("Channel", "Channel/{ChannelID}", "~/Portal/TemplateEngine/Channel.aspx", false, defChannel);
            RouteTable.Routes.MapPageRoute("ChannelDetail", "Detail/{ChannelID}_{RecordID}", "~/Portal/TemplateEngine/Detail.aspx");
            RouteTable.Routes.MapPageRoute("Detail", "Detail/{RecordID}", "~/Portal/TemplateEngine/Detail.aspx");
            RouteTable.Routes.MapPageRoute("ModelQuery", "ModelQuery/{Model}", "~/Model/ModelQuery.aspx");
            RouteTable.Routes.MapPageRoute("ModelEdit", "ModelEdit/{Model}", "~/Model/ModelEdit.aspx");

            RouteValueDictionary defaults = new RouteValueDictionary();
            defaults.Add("PortalCode", "Default");

            RouteTable.Routes.MapPageRoute("Portal", "Portal/{PortalCode}", "~/Portal.aspx");
        }

        protected override void RegisterComponents(ContainerBuilder builder)
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