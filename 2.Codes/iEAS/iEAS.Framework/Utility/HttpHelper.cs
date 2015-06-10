using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace iEAS.Utility
{
    public class HttpHelper
    {
        public static string ValueRequest(string key)
        {
            return Request[key];
        }

        public static HttpRequest Request
        {
            get { return HttpContext.Current.Request; }
        }

        public static HttpResponse Response
        {
            get { return HttpContext.Current.Response; }
        }
    }
}
