using iEAS.Infrastructure.UI;
using iEAS.Orgnization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iEAS.Infrastructure.Web.Pages.Orgnization
{
    public partial class EmployeeEdit : EditForm
    {
        public IEmployeeService EmployeeService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var employee = EmployeeService.GetByID(RecordID);

            if (employee == null)
            {
                employee = new Employee();
            }

            employee.ChineseName = txtChinesename.Text.Trim();
            employee.EnglishName = txtEnglishName.Text.Trim();
            employee.EmployeeNumber = txtEmployeeNumber.Text.Trim();
            employee.Desc = txtDesc.Text.Trim();
            employee.Status = 1;

            try
            {
                EmployeeService.CreateOrUpdate(employee);
            }
            catch (Exception ex)
            {
                LogManager.GetLogger().Error("保存出错！", ex);
                throw ex;
            }
            Response.Redirect("EmployeeList.aspx");
        }

        private void BindData()
        {
            var employee = EmployeeService.GetByID(RecordID);
            if (employee != null)
            {
                txtChinesename.Text = employee.ChineseName;
                txtEnglishName.Text = employee.EnglishName;
                txtEmployeeNumber.Text = employee.EmployeeNumber;
                txtDesc.Text = employee.Desc;
            }
        }
    }
}