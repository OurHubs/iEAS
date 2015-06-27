using iEAS.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iEAS.Infrastructure.Web.Portal.TemplateEngine
{
    public partial class Channel : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            LoadTempalte();
            base.OnInit(e);
        }

        public int ChannelID
        {
            get
            {
                return RouteData.Values["ChannelID"].ToString().ToInt();
            }
        }

        private void LoadTempalte()
        {
            IChannelService ChannelService = ObjectContainer.GetService<IChannelService>();
            Module.Channel channel=ChannelService.GetByID(ChannelID);

            var template = Page.LoadControl("~/_Templates/Default/ChannelList.ascx");
            
            this.Controls.Clear();
            this.Controls.Add(template);
        }

    }
}