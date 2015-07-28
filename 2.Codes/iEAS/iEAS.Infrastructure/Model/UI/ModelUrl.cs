using iEAS.Model.Config;
using iEAS.Model.Data;
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
            string channelSN = record.GetStr("ChannelSN");
            return !String.IsNullOrWhiteSpace(channelSN)
                ? String.Format("/Detail/{0}_{1}", channelSN, recordID)
                : String.Format("/Detail/{0}", recordID);
        }

        public static string GetChannelUrl(this Page page,int pageIndex)
        {
            var channelSN = page.RouteData.Values["ChannelSN"];
            return String.Format("/Channel/{0}_{1}", channelSN, pageIndex);
        }

        public static string GetChannelUrl(this Page page)
        {
            var channelSN = page.RouteData.Values["ChannelSN"];
            return String.Format("/Channel/{0}", channelSN);
        }
    }
}
