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
            if(!Page.ClientScript.IsStartupScriptRegistered(Page.GetType(),"alert:" + message))
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "alert:" + message, "alert('" + message + "')", true);
            }
        }
    }
}
