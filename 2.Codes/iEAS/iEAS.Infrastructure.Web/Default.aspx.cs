using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iEAS.Infrastructure.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try { 
             var user=SessionContext.Current.User;
             var roles = SessionContext.Current.Roles;
             var modules = SessionContext.Current.Modules;
             var menus = SessionContext.Current.Menus;
                }
            catch(Exception ex)
            {
                Response.Redirect("~/Test.aspx");
            }
        }
    }
}