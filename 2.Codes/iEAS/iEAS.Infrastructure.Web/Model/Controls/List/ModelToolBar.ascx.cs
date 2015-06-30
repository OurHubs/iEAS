using iEAS.Model.Config;
using iEAS.Model.UI;
using iEAS.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iEAS.Infrastructure.Web.Model.Template.List
{
    public partial class ModelToolBar : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindToolbar();
            }
        }

        public void BindToolbar()
        {
            rptToolBar.DataSource = ModelContext.Current.List.TopBar;
            rptToolBar.DataBind();
        }

        protected void rptToolBar_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    string queryString = HttpHelper.GetQueryString();
                    if (!String.IsNullOrEmpty(queryString))
                    {
                        Response.Redirect("/ModelEdit/" + ModelContext.Current.List.Code+"?"+queryString);
                    }
                    else
                    {
                        Response.Redirect("/ModelEdit/" + ModelContext.Current.List.Code);
                    }
                    break;

                default:
                    break;
            }
        }
    }
}