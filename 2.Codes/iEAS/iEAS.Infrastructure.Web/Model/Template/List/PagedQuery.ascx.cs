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
            ModelResult result = engine.PagedQuery(ModelContext.Current.List, new Dictionary<string, object>(),Pager.CurrentPageIndex,Pager.PageSize);

            gvList.DataSource = result;
            gvList.DataBind();

            Pager.RecordCount = result.RecordCount;
        }

        protected void gvList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                DBEngine engine = new DBEngine();
                engine.DeleteRecord(ModelContext.Current.List, e.CommandArgument.ToString().ToGuid());
            }

            e.Handled = true;

            BindData();
        }

        protected void Pager_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            Pager.CurrentPageIndex = e.NewPageIndex;
            BindData();
        }
    }
}