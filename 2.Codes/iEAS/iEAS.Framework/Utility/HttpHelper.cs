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

        public static string ValueRequest(string key)
        {
            return Request[key];
        }

        public static string RouteValue(string key)
        {
            return Page.RouteData.Values[key].ToStr(null);
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
