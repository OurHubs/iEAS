using iEAS.Model.UI;
using iEAS.Module;
using iEAS.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iEAS.Infrastructure.Web.Model.Controls.Field
{
    public partial class ChannelRequest : ModelFieldControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblChannelName.Text = hfChannelName.Value;
        }

        public override void InitControl(iEAS.Model.Data.Record record)
        {
            if (!IsPostBack)
            {
                IChannelService channelService = ObjectContainer.GetService<IChannelService>();

                Channel channel = null;
                if (record != null && record.Items.ContainsKey(Field.Code))
                {
                    channel = channelService.GetByID(record.Items.GetValue(Field.Code).ToStr("0").ToInt());
                }
                if (channel == null)
                {
                    int channelID = HttpHelper.RequestValue("cid").ToInt(0);
                    channel = channelService.GetByID(channelID);
                }
                if (channel != null)
                {
                    lblChannelName.Text = channel.Name;
                    hfChannelID.Value = channel.ID.ToString();
                    hfChannelName.Value = channel.Name;
                    hfChannelGuid.Value = channel.Guid.ToStr();
                }
            }
        }

        public override Dictionary<string, object> GetValues()
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            result.Add(Field.Code, hfChannelID.Value.ToNInt());
            if (Field.Params.ContainsKey("NameField"))
            {
                result.Add(Field.Params["NameField"], hfChannelName.Value);
            }
            if (Field.Params.ContainsKey("GuidField"))
            {
                result.Add(Field.Params["GuidField"], hfChannelGuid.Value);
            }
            return result;
        }
    }
}