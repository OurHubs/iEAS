using iEAS.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iEAS.Infrastructure.Web.Portal.TemplateEngine
{
    public partial class Detail : System.Web.UI.Page
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
                return RouteData.Values["ChannelSN"].ToStr().ToInt(0);
            }
        }

        private void LoadTempalte()
        {
            string tplPath = "~/_Templates/Default/ChannelDetail.ascx";
            if (ChannelSN != 0)
            {
                IChannelService ChannelService = ObjectContainer.GetService<IChannelService>();
                Module.Channel channel = ChannelService.GetBySN(ChannelSN);
                if (!String.IsNullOrEmpty(channel.Template))
                {
                    tplPath = "~/_Templates/Default/ChannelDetail.ascx";
                }
            }
            Control template = Page.LoadControl(tplPath);
            this.Controls.Clear();
            this.Controls.Add(template);
        }
    }
}