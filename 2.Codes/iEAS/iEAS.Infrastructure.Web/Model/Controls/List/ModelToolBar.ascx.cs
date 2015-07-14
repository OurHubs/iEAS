using iEAS.Model.Config;
using iEAS.Model.Data;
using iEAS.Model.UI;
using iEAS.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
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
                case "DeleteAll":
                    string[] ids=GetRecordIds();
                    if(ids.Length>0)
                    {
                        DBEngine engine = new DBEngine();
                        engine.DeleteRecord(ModelContext.Current.List, ids);
                    }
                    PagedQuery.BindData();
                    break;
                default:
                    break;
            }
        }

        protected string[] GetRecordIds()
        {
            List<string> chkRecords=new List<string>();
            foreach(GridViewRow row in PagedQuery.gvList.Rows)
            {
                var chkRecord = row.FindControl("RecordID") as HtmlInputCheckBox;
                if(chkRecord.Checked)
                {
                    chkRecords.Add(chkRecord.Value);
                }
            }
            return chkRecords.ToArray();
        }

        public PagedQuery PagedQuery
        {
            get { return this.NamingContainer as PagedQuery; }
        }
    }
}