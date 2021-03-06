﻿using iEAS.Account;
using iEAS.Infrastructure.UI;
using iEAS.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iEAS.Infrastructure.Web.Pages.Account
{
    public partial class RoleList : ListForm
    {
        public IRoleService RoleService { get; set; }

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
            Pager.CurrentPageIndex = e.NewPageIndex;
            BindData();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("RoleEdit.aspx");
        }

        protected void btnDeleteAll_Click(object sender, EventArgs e)
        {
            Guid[] ids = HttpHelper.GetRequestIds("ids");
            if (ids.Count() > 0)
            {
                RoleService.Delete(m => ids.Contains(m.ID));
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
                RoleService.DeleteByID(rid);
                BindData();
            }
        }

        private void BindData()
        {
            var query = RoleService.Query().Where(m => m.Status == 1);
            string name = txtName.Text.Trim();
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(m => m.Name.Contains(name));
            }
            var result = query.PagedQuery(o => o.Desc(m => m.SN), Pager.CurrentPageIndex, Pager.PageSize);
            gvList.DataSource = result;
            gvList.DataBind();
            Pager.RecordCount = result.RecordCount;
        }
    }
}