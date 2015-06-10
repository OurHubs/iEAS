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
                BindHeader();
            }
        }

        protected IPageableDataSource odsQuery_Query(object sender, iEAS.Web.UI.ObjectDataSourceEventArgs args)
        {
            return new DBEngine().PagedQuery(ModelContext.Current.List, new Dictionary<string, object>(), args.startRowIndex, args.maxRows);
        }

        protected void lvQuery_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                Guid rid = e.CommandArgument.ToString().ToGuid();
                new DBEngine().DeleteRecord(ModelContext.Current.List, rid);
                lvQuery.DataBind();
            }
        }

        protected object UxEval(RepeaterItem container)
        {
            object record = ((ListViewItem)container.NamingContainer).DataItem;
            ModelColumn column = container.DataItem as ModelColumn;
            return DataBinder.Eval(record, column.Code);
        }

        protected void rptCells_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            object record = ((ListViewItem)e.Item.NamingContainer.NamingContainer).DataItem;
            ModelColumn column = e.Item.DataItem as ModelColumn;
            if (column.Type == "Text")
            {
                e.Item.FindControl("phContainer").Controls.Add(new Literal() { Text = DataBinder.Eval(record, column.Code) + "" });
            }
        }

        private void BindHeader()
        {
            rptHeader.DataSource = ModelContext.Current.List.Columns;
            rptHeader.DataBind();
        }

        private void BindCells(Repeater rptCells)
        {
            rptCells.DataSource = ModelContext.Current.List.Columns;
            rptCells.DataBind();
        }

        protected void lvQuery_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            BindCells(e.Item.FindControl("rptCells") as Repeater);
        }
    }
}