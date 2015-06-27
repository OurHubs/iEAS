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
        protected override void OnInit(EventArgs e)
        {
            InitConidtions();
            InitGrid();
            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindData();
            }
        }

        private void InitGrid()
        {
            foreach(var column in ModelContext.Current.List.Columns)
            {
                ModelBindField field = new ModelBindField();
                field.ModelColumn = column;
                field.HeaderStyle.Width = Unit.Parse("200px");
                gvList.Columns.Add(field);
            }
        }

        private void InitConidtions()
        {
            rptConditions.DataSource = ModelContext.Current.List.Conditions;
            rptConditions.DataBind();
        }

        private void BindData()
        {
            Dictionary<string, object> parameters = PopulateParameters();

            DBEngine engine = new DBEngine();
            ModelResult result = engine.PagedQuery(ModelContext.Current.List, parameters, Pager.CurrentPageIndex, Pager.PageSize);

            gvList.DataSource = result;
            gvList.DataBind();

            Pager.RecordCount = result.RecordCount;
        }

        protected void gvList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                DBEngine engine = new DBEngine();
                engine.DeleteRecord(ModelContext.Current.List, e.CommandArgument.ToGuid());
                BindData();
            }
            else if (e.CommandName == "Edit")
            {
                Response.Redirect("ModelEdit.aspx?model=" + ModelContext.Current.List.Code + "&rid=" + e.CommandArgument.ToGuid());
            }

            e.Handled = true;

            
        }

        protected void Pager_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            Pager.CurrentPageIndex = e.NewPageIndex;
            BindData();
        }

        protected void rptConditions_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            ModelCondition condition=e.Item.DataItem as ModelCondition;
            ModelFieldContainer ctField = e.Item.FindControl("ctField") as ModelFieldContainer;
            ctField.FieldCode=condition.Code;
            ctField.IsCondition = true;
            ctField.BindField(null);
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            Pager.CurrentPageIndex = 1;
            BindData();
        }

        private Dictionary<string,object> PopulateParameters()
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            foreach(RepeaterItem item in rptConditions.Items)
            {
                ModelFieldContainer ctField=item.FindControl("ctField") as ModelFieldContainer;
                Dictionary<string,object> values=ctField.GetValues();
                foreach(var kvp in values)
                {
                    result.Add(kvp.Key, kvp.Value);
                }
            }
            return result;
        }
    }
}