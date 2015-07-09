using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;

namespace iEAS.Utility
{
    public static class HttpHelper
    {

        public static StateBag GetViewState(this Control control)
        {
            StateBag bag= control.GetType().GetProperty("ViewState",BindingFlags.NonPublic|BindingFlags.Instance).GetValue(control,null) as StateBag;
            return bag;
        }

        public static string RequestValue(string key)
        {
            return Request[key];
        }

        public static string RouteValue(string key)
        {
            return Page.RouteData.Values[key].ToStr(null);
        }

        public static string GetQueryString()
        {
            StringBuilder sbStr = new StringBuilder();
            foreach(string key in Request.QueryString.AllKeys)
            {
                string[] values=Request.QueryString.GetValues(key);
                foreach(var value in values)
                {
                    sbStr.AppendFormat("{0}={1}&", key, value);
                }
            }
            sbStr.Trim('&');
            return sbStr.ToString();
        } 

        /// <summary>
        /// 获取请求的ID列表
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static Guid[] GetRequestIds(string key)
        {
            string strIds=Request[key];
            if (String.IsNullOrWhiteSpace(strIds))
                return new Guid[0];
            return strIds.Split(',').Select(m => m.ToGuid()).ToArray();
        }

        public static HttpRequest Request
        {
            get { return HttpContext.Current.Request; }
        }

        public static HttpResponse Response
        {
            get { return HttpContext.Current.Response; }
        }

        public static Page Page
        {
            get { return HttpContext.Current.Handler as Page; }
        }
    }
}
