using iEAS.Infrastructure.UI;
using iEAS.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iEAS.Infrastructure.Web.Portal.TemplateEngine
{
    public partial class Channel : EditForm
    {
        protected override void OnInit(EventArgs e)
        {
            LoadTempalte();
            base.OnInit(e);
        }

        public int ChannelSN
        {
            get
            {
                return RouteData.Values["ChannelSN"].ToString().ToInt();
            }
        }

        private void LoadTempalte()
        {
            IChannelService ChannelService = ObjectContainer.GetService<IChannelService>();
            Module.Channel channel=ChannelService.GetBySN(ChannelSN);
            Control template = null;
            if (!String.IsNullOrEmpty(channel.Template))
            {
                template = Page.LoadControl("~/_Templates/Default/"+channel.Template+".ascx");
            }
            else
            {
                template = Page.LoadControl("~/_Templates/Default/ChannelPage.ascx");
            }
            
            this.Controls.Clear();
            this.Controls.Add(template);
        }

    }
}