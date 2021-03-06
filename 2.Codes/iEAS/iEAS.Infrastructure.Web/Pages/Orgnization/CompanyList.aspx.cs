﻿using iEAS.Infrastructure.UI;
using iEAS.Orgnization;
using iEAS.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iEAS.Infrastructure.Web.Pages.Orgnization
{
    public partial class CompanyList : ListForm
    {
        public ICompanyService CompanyService { get; set; }

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

        protected void btnDeleteAll_Click(object sender, EventArgs e)
        {
            Guid[] ids = HttpHelper.GetRequestIds("ids");
            CompanyService.Delete(m => ids.Contains(m.ID));
            BindData();
            if (ids == null || ids.Length <= 0) { ScriptHelper.Alert("请选择您要删除的记录！"); }
            else
            {
                ScriptHelper.Alert("操作成功！");
            }
        }

        protected void gvList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                Guid rid = e.CommandArgument.ToGuid();
                CompanyService.DeleteByID(rid);
                BindData();
            }
        }

        private void BindData()
        {
            var query = CompanyService.Query().Where(m => m.Status == 1);

            string name = txtName.Text.Trim();
            if(!String.IsNullOrWhiteSpace(name))
            {
                query = query.Where(m => m.Name.Contains(name));
            }

            string code = txtCode.Text.Trim();
            if (!String.IsNullOrWhiteSpace(code))
            {
                query = query.Where(m => m.Code.Contains(code));
            }

            var result = query.PagedQuery( o => o.Desc(m => m.SN), Pager.CurrentPageIndex, Pager.PageSize);
            gvList.DataSource = result;
            gvList.DataBind();
            Pager.RecordCount = result.RecordCount;
        }
    }
}