using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;

namespace iEAS
{
    public class ScriptHelper
    {
        static Page Page
        {
            get
            {
                return HttpContext.Current.Handler as Page;
            }
        }

        public static void Alert(string message)
        {
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "alert:" + message, "alert('" + message + "')", true);
        }
    }
}
