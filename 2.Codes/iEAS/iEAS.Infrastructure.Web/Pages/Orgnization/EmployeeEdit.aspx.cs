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

        public Guid DepartmentID
        {
            get
            {
                Guid? departmentId = Request["departmentId"].ToNGuid();
                if (departmentId == null)
                {
                    throw new BusinessException("部门ID不能为空！");
                }
                return departmentId.Value;
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
            employee.AreaName = txtAreaName.Text.Trim();
            employee.Email = txtEmail.Text.Trim();
            employee.Email2 = txtEmail2.Text.Trim();
            employee.Fax = txtFax.Text.Trim();
            employee.Gender = Convert.ToInt16(rblGender.SelectedValue);
            employee.HomeAddress = txtHomeAddress.Text.Trim();
            //employee.Birthday = txtBirthday.Text.Trim();
            //employee.HiredDate = txtHiredDate.Text.Trim();
            //employee.HomeCity=
            //employee.HomeCityName=
            //employee.HomeCountry =
            //employee.HomeCountryName =
            //employee.HomeCounty
            //employee.HomeCountyName
            employee.HomePhone = txtHomePhone.Text.Trim();
            //employee.HomeProvince=
            //employee.HomeProvinceName
            //employee.TerminatedDate=txtTerminatedDate
            employee.HomeZipCode = txtHomeZipCode.Text.Trim();
            employee.JobGrade = ddlJobGrade.SelectedValue;
            //employee.Location=
            //employee.LocationName =
            employee.MobilePhone = txtMobilePhone.Text.Trim();
            employee.MobilePhone2 = txtMobilePhone2.Text.Trim();
            employee.OfficePhone = txtOfficePhone.Text.Trim();
            employee.WorkAddress = txtWorkAddress.Text.Trim();
            employee.WorkCity = txtWorkCityName.Text.Trim();
            employee.WorkCityName = txtWorkCityName.Text.Trim();
            //employee.WorkCountry=txtWorkCountryName.Text.Trim();
            employee.WorkCountryName = txtWorkCountryName.Text.Trim();
            //employee.WorkCounty=txtWorkCountyName.Text.Trim();
            employee.WorkCountyName = txtWorkCountyName.Text.Trim();
            employee.WorkProvince = txtWorkProvinceName.Text.Trim();
            employee.WorkProvinceName = txtWorkProvinceName.Text.Trim();
            employee.WorkStatus = Convert.ToInt16(ddlWorkStatus.SelectedValue);
            employee.WorkZipCode = txtWorkZipCode.Text.Trim();
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
            Response.Redirect("EmployeeList.aspx?departmentID=" + DepartmentID);
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
                txtAreaName.Text = employee.AreaName;
                txtEmail.Text = employee.Email;
                txtEmail2.Text = employee.Email2;
                txtFax.Text = employee.Fax;
                int gender;
                rblGender.SelectedValue = int.TryParse(employee.Gender.ToString(), out gender) == true ? "" : gender.ToString();
                txtHomeAddress.Text = employee.HomeAddress;
                //txtBirthday.Text=employee.Birthday ;
                //txtHiredDate.Text=employee.HiredDate ;
                txtHomePhone.Text=employee.HomePhone ;
                //txtTerminatedDate.text=employee.TerminatedDate;
                txtHomeZipCode.Text = employee.HomeZipCode;
                ddlJobGrade.SelectedValue = employee.JobGrade;
                txtMobilePhone.Text = employee.MobilePhone;
                txtMobilePhone2.Text = employee.MobilePhone2;
                txtOfficePhone.Text = employee.OfficePhone;
                txtWorkAddress.Text = employee.WorkAddress;
                txtWorkCityName.Text = employee.WorkCity;
                txtWorkCityName.Text = employee.WorkCityName;
                txtWorkCountryName.Text = employee.WorkCountryName;
                txtWorkCountyName.Text = employee.WorkCountyName;
                txtWorkProvinceName.Text = employee.WorkProvince;
                txtWorkProvinceName.Text = employee.WorkProvinceName;
                int workstatus;
                ddlWorkStatus.SelectedValue = int.TryParse(employee.WorkStatus.ToString(), out workstatus) == true ? "" : workstatus.ToString();
                txtWorkZipCode.Text = employee.WorkZipCode;
            }
        }
    }
}