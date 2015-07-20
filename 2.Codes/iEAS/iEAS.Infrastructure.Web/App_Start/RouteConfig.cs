using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace iEAS.Infrastructure.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            RouteTable.Routes.MapPageRoute("Home", "", "~/Portal/TemplateEngine/Home.aspx");
            RouteValueDictionary defChannel = new RouteValueDictionary();
            defChannel.Add("PageIndex", 1);
            RouteTable.Routes.MapPageRoute("ChannelList", "Channel/{ChannelID}_{PageIndex}", "~/Portal/TemplateEngine/Channel.aspx", false, defChannel);
            RouteTable.Routes.MapPageRoute("Channel", "Channel/{ChannelID}", "~/Portal/TemplateEngine/Channel.aspx", false, defChannel);
            RouteTable.Routes.MapPageRoute("ChannelDetail", "Detail/{ChannelID}_{RecordID}", "~/Portal/TemplateEngine/Detail.aspx");
            RouteTable.Routes.MapPageRoute("Detail", "Detail/{RecordID}", "~/Portal/TemplateEngine/Detail.aspx");
            RouteTable.Routes.MapPageRoute("ModelQuery", "ModelQuery/{Model}", "~/Model/ModelQuery.aspx");
            RouteTable.Routes.MapPageRoute("ModelEdit", "ModelEdit/{Model}", "~/Model/ModelEdit.aspx");

            RouteValueDictionary defaults = new RouteValueDictionary();
            defaults.Add("PortalCode", "Default");

            RouteTable.Routes.MapPageRoute("Portal", "Portal/{PortalCode}", "~/Portal.aspx");
        }
    }
}
