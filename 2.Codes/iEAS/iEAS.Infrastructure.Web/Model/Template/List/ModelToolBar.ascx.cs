using iEAS.Model.Config;
using iEAS.Model.UI;
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
                    Response.Redirect("~/Model/ModelEdit.aspx?model=" + ModelContext.Current.Config.Code);
                    break;

                default:
                    break;
            }
        }
    }
}