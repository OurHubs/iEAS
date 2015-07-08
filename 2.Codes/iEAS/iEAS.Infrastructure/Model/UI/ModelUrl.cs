using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace iEAS.Model.UI
{
    public static class ModelUrl
    {
        public static string GetDetailUrl(this IReadOnlyDictionary<string, object> record)
        {
            string recordID = record.GetStr("RecordID");
            string channelID = record.GetStr("ChannelID");
            return !String.IsNullOrWhiteSpace(channelID)
                ? String.Format("/Detail/{0}_{1}", channelID, recordID)
                : String.Format("/Detail/{0}", recordID);
        }

        public static string GetChannelUrl(this Page page,int pageIndex)
        {
            var channelID = page.RouteData.Values["ChannelID"];
            return String.Format("/Channel/{0}_{1}", channelID, pageIndex);
        }

        public static string GetChannelUrl(this Page page)
        {
            var channelID = page.RouteData.Values["ChannelID"];
            return String.Format("/Channel/{0}", channelID);
        }
    }
}
