using iEAS.Orgnization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iEAS.Infrastructure.Web.Pages.Controls
{
    public partial class UxEmployeeSelect : System.Web.UI.UserControl
    {
        public IEmployeeService EmployeeService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public Employee GetEmployee()
        {
            Guid? eid = hfEmpId.Value.ToNGuid();
            if (eid != null)
            {
                return EmployeeService.GetByID(eid.Value);
            };
            return null;
        }

        public void BindEmployee(Guid employeeId)
        {
            var employee = EmployeeService.GetByID(employeeId);
            hfEmpId.Value = employee.ID.ToStr();
            hfEmpNumber.Value = employee.EmployeeNumber;
            hfEmpName.Value = employee.ChineseName;
        }


    }
}