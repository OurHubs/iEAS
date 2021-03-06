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
    public partial class EmployeeList : ListForm
    {
        public IDepartmentService DepartmentService { get; set; }
        public IEmployeeService EmployeeService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        public Guid? DepartmentID
        {
            get 
            {
                return Request["departmentId"].ToNGuid();
            }
        }

        public Guid? CompanyID
        {
            get
            {
                return Request["CompanyID"].ToNGuid();
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
            EmployeeService.Delete(m => ids.Contains(m.ID));
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
                EmployeeService.DeleteByID(rid);
                BindData();
            }
        }

        private void BindData()
        {
            var query = EmployeeService.Query().Where(m => m.Status == 1);

            string name = txtName.Text.Trim();
            if (!String.IsNullOrWhiteSpace(name))
            {
                query = query.Where(m => m.ChineseName.Contains(name)|| m.EnglishName.Contains(name));
            }

            string employeeNumber = txtEmployeeNumber.Text.Trim();
            if (!String.IsNullOrWhiteSpace(employeeNumber))
            {
                query = query.Where(m => m.EmployeeNumber.Contains(employeeNumber));
            }

            if(DepartmentID!=null)
            {
                var deptId = DepartmentID.Value;
                query = query.Where(m => m.DepartmentPostions.Any(p => p.DepartmentID == deptId));
            }

            if(CompanyID!=null)
            {
                var cid = CompanyID.Value;
                query = query.Where(m => m.DepartmentPostions.Any(p => p.Department.CompanyID == cid));
            }

            var result = query.PagedQuery(o => o.Desc(m => m.SN), Pager.CurrentPageIndex, Pager.PageSize);
            gvList.DataSource = result;
            gvList.DataBind();
            Pager.RecordCount = result.RecordCount;
        }
        
        protected string GetDeptName(object item)
        {
            Employee employee = item as Employee;
            return String.Join(",",employee.DepartmentPostions.Select(m => m.Department.Name).Distinct().ToArray());
        }
    }
}