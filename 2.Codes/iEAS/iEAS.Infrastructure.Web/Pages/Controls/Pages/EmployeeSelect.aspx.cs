using iEAS.Orgnization;
using iEAS.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iEAS.Infrastructure.Web.Pages.Controls.Pages
{
    public partial class EmployeeSelect : System.Web.UI.Page
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

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void Pager_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            Pager.CurrentPageIndex = e.NewPageIndex;
            BindData();
        }

        private void BindData()
        {
            var query = EmployeeService.Query().Where(m => m.Status == 1);

            string name = txtName.Text.Trim();
            if (!String.IsNullOrWhiteSpace(name))
            {
                query = query.Where(m => m.ChineseName.Contains(name) || m.EnglishName.Contains(name));
            }

            string employeeNumber = txtEmployeeNumber.Text.Trim();
            if (!String.IsNullOrWhiteSpace(employeeNumber))
            {
                query = query.Where(m => m.EmployeeNumber.Contains(employeeNumber));
            }

            var result = query.PagedQuery(o => o.Desc(m => m.SN), Pager.CurrentPageIndex, Pager.PageSize);
            gvList.DataSource = result;
            gvList.DataBind();
            Pager.RecordCount = result.RecordCount;
        }

        protected string GetDeptName(object item)
        {
            Employee employee = item as Employee;
            return String.Join(",", employee.DepartmentPostions.Select(m => m.Department.Name).ToArray());
        }
    }
}