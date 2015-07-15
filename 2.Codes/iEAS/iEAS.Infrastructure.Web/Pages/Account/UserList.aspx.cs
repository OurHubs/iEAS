
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iEAS.Infrastructure.UI;
using iEAS.Utility;
using iEAS.Account;
namespace iEAS.Infrastructure.Web.Pages.Account
{
    public partial class UserList : ListForm
    {
        public IUserService UserService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            var query = UserService.Query().Where(m => m.Status == 1);

            string name= txtName.Text.Trim();
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(m => m.Name.Contains(name));
            }

            var result = query.PagedQuery(o => o.Desc(m => m.SN), aspnetpage.CurrentPageIndex, aspnetpage.PageSize);
            gvList.DataSource = result;
            gvList.DataBind();
            aspnetpage.RecordCount = result.RecordCount;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserEdit.aspx");
        }

        protected void btnDeleteAll_Click(object sender, EventArgs e)
        {
            Guid[] ids = HttpHelper.GetRequestIds("ids");
            UserService.Delete(m => ids.Contains(m.ID));
            BindData();
            ScriptHelper.Alert("操作成功！");
        }

        protected void gvList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                Guid rid = e.CommandArgument.ToGuid();
                UserService.DeleteByID(rid);
                BindData();
            }
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void Pager_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            aspnetpage.CurrentPageIndex = e.NewPageIndex;
            BindData();
        }

    }
}