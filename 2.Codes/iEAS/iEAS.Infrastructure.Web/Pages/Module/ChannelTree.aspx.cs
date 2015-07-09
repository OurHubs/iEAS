using iEAS.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iEAS.Infrastructure.Web.Pages.Module
{
    public partial class ChannelTree : System.Web.UI.Page
    {
        public IChannelService ChannelService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string BuildChannel()
        {
            var channels = ChannelService.Query(m =>  m.Status == 1, o => o.Asc(m => m.Sort));

            StringBuilder sbChannel = new StringBuilder();
            sbChannel.Append("[");

            foreach (var channel in channels)
            {
                sbChannel.AppendFormat("{{id:{0},pId:{1},name:'{2}',guid:'{3}',open:true,url:'{4}',target:'main'}},", channel.ID, channel.ParentID.ToStr("null"), channel.Name, channel.ID, GetUrl(channel));
            }
            sbChannel.Trim(',').Append(']');
            return sbChannel.ToString();
        }

        private string GetUrl(Channel channel)
        {
            if (String.IsNullOrWhiteSpace(channel.ChannelType))
                return String.Empty;

            switch (channel.ChannelType.ToUpper())
            {
                case "URL":
                    return channel.Url;
                case "NODE":
                    return "";
                case "MODEL":
                    return "/ModelQuery/" + channel.Model + "?cid=" + channel.ID;
                case "PMODEL":
                    return "/ModelEdit/" + channel.Model + "?cid=" + channel.ID;
            }
            return String.Empty;
        }
    }
}