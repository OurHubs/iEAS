﻿using iEAS.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iEAS.Utility;

namespace iEAS.Infrastructure.Web.Pages.Module
{
    public partial class ModuleList : System.Web.UI.Page
    {
        public IModuleService ModuleService { get; set; }

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
            Response.Redirect("ModuleEdit.aspx");
        }

        protected void btnDeleteAll_Click(object sender, EventArgs e)
        {
            Guid[] ids = HttpHelper.GetRequestIds("ids");
            if (ids.Count() > 0)
            {
                ModuleService.Delete(m => ids.Contains(m.ID));
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
                ModuleService.DeleteByID(rid);
                BindData();
            }
        }

        private void BindData()
        {
            var query = ModuleService.Query().Where(m => m.Status == 1);

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