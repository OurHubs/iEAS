using iEAS.Model.Config;
using iEAS.Model.Data;
using iEAS.Model.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iEAS.Infrastructure.Web.Model.Template.List
{
    public partial class PagedQuery : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                InitGrid();
                BindData();
            }
        }

        private void InitGrid()
        {
            foreach(var column in ModelContext.Current.List.Columns)
            {
                ModelBindField field = new ModelBindField();
                field.ModelColumn = column;
                gvList.Columns.Add(field);
            }
        }

        private void BindData()
        {
            DBEngine engine = new DBEngine();
            gvList.DataSource = engine.PagedQuery(ModelContext.Current.List, new Dictionary<string, object>(), 0, 10);
                gvList.DataBind();
        }

        protected void gvList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {

            }

            BindData();
        }
    }
}