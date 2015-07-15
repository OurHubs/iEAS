using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iEAS.Module;
using iEAS.Utility;


namespace iEAS.Infrastructure.Web.Pages.Module
{
    public partial class PortalList : System.Web.UI.Page
    {
        public IPortalService PortalService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void Pager_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            aspnetpager.CurrentPageIndex = e.NewPageIndex;
            BindData();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("PortalEdit.aspx");
        }

        protected void btnDeleteAll_Click(object sender, EventArgs e)
        {
            Guid[] ids = HttpHelper.GetRequestIds("ids");
            if (ids.Count() > 0)
            {
                PortalService.Delete(m => ids.Contains(m.ID));
                BindData();
                ScriptHelper.Alert("操作成功！");
            }
            else
            {
                ScriptHelper.Alert("请勾选要删除的行！");
            }
        }

        protected void gvList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                Guid rid = e.CommandArgument.ToGuid();
                PortalService.DeleteByID(rid);
                BindData();
            }
        }

        private void BindData()
        {
            var query = PortalService.Query().Where(m => m.Status == 1);

            string name = txtName.Text.Trim();
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(m => m.Name.Contains(name));
            }

            var result = query.PagedQuery(o => o.Desc(m => m.SN), aspnetpager.CurrentPageIndex, aspnetpager.PageSize);
            gvList.DataSource = result;
            gvList.DataBind();
            aspnetpager.RecordCount = result.RecordCount;
        }

        
    }
}