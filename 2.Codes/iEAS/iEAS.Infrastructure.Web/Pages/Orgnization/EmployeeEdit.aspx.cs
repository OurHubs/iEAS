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
        public ITitleService TitleService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitControls();
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
            //employee.AreaName = txtAreaName.Text.Trim();
            employee.Email = txtEmail.Text.Trim();
            employee.Email2 = txtEmail2.Text.Trim();
            employee.Fax = txtFax.Text.Trim();
            employee.Gender = Convert.ToInt32(rblGender.SelectedValue);
            //employee.HomeAddress = txtHomeAddress.Text.Trim();
            //employee.Birthday = txtBirthday.Text.Trim();
            //employee.HiredDate = txtHiredDate.Text.Trim();
            //employee.HomeCity=
            //employee.HomeCityName=
            //employee.HomeCountry =
            //employee.HomeCountryName =
            //employee.HomeCounty
            //employee.HomeCountyName
            //employee.HomePhone = txtHomePhone.Text.Trim();
            //employee.HomeProvince=
            //employee.HomeProvinceName
            //employee.TerminatedDate=txtTerminatedDate
            //employee.HomeZipCode = txtHomeZipCode.Text.Trim();
            employee.JobGrade = ddlJobGrade.SelectedValue;
            //employee.Location=
            //employee.LocationName =
            employee.MobilePhone = txtMobilePhone.Text.Trim();
            employee.MobilePhone2 = txtMobilePhone2.Text.Trim();
            employee.OfficePhone = txtOfficePhone.Text.Trim();
            employee.WorkAddress = txtWorkAddress.Text.Trim();
            //employee.WorkCity = txtWorkCityName.Text.Trim();
            //employee.WorkCityName = txtWorkCityName.Text.Trim();
            //employee.WorkCountry=txtWorkCountryName.Text.Trim();
            //employee.WorkCountryName = txtWorkCountryName.Text.Trim();
            //employee.WorkCounty=txtWorkCountyName.Text.Trim();
            //employee.WorkCountyName = txtWorkCountyName.Text.Trim();
            //employee.WorkProvince = txtWorkProvinceName.Text.Trim();
            //employee.WorkProvinceName = txtWorkProvinceName.Text.Trim();
            employee.WorkStatus = Convert.ToInt32(ddlWorkStatus.SelectedValue);
            //employee.WorkZipCode = txtWorkZipCode.Text.Trim();
            employee.Status = 1;
            var empReportLine = uxEmployeeSelect.GetEmployee();
            if (empReportLine != null)
            {
                employee.ReportLine = empReportLine.ID;
            }

            try
            {
                using(var ctx=EmployeeService.BeginContext())
                {
                    EmployeeService.CreateOrUpdate(employee);
                    TitleService.JoinContext(ctx);

                    IEmployeePositionService employeePostionService=ctx.GetService<IEmployeePositionService>();
                    ctx.Set<EmployeePosition>().RemoveRange(ctx.Set<EmployeePosition>().Where(m => m.EmployeeID == employee.ID));
                    
                    var positionIds=uxPositionSelect.GetPostionIds();
                    foreach(var kvp in positionIds)
                    {
                        EmployeePosition employeePosition = new EmployeePosition();
                        employeePosition.EmployeeID = employee.ID;
                        employeePosition.DepartmentID = kvp.Key;
                        employeePosition.PositionID = kvp.Value;
                        employeePostionService.Create(employeePosition);
                    }
                    
                    employee.Titles.Clear();
                    foreach(ListItem item in lstTitle.Items)
                    {
                        if (item.Selected)
                        {
                            employee.Titles.Add(TitleService.GetByID(item.Value.ToGuid()));
                        }
                    }

                    ctx.Commit();
                }
            }
            catch (Exception ex)
            {
                LogManager.GetLogger().Error("保存出错！", ex);
                throw ex;
            }
            Response.Redirect("EmployeeList.aspx?departmentID=" + DepartmentID+"&companyId="+CompanyID);
        }

        private void BindData()
        {
            var employee = EmployeeService.GetByID(RecordID,true);
            if (employee != null)
            {
                txtChinesename.Text = employee.ChineseName;
                txtEnglishName.Text = employee.EnglishName;
                txtEmployeeNumber.Text = employee.EmployeeNumber;
                txtDesc.Text = employee.Desc;
                //txtAreaName.Text = employee.AreaName;
                txtEmail.Text = employee.Email;
                txtEmail2.Text = employee.Email2;
                txtFax.Text = employee.Fax;
                int gender;
                rblGender.SelectedValue = employee.Gender == 0 ? "0" : "1";
                //txtHomeAddress.Text = employee.HomeAddress;
                //txtBirthday.Text=employee.Birthday ;
                //txtHiredDate.Text=employee.HiredDate ;
                //txtHomePhone.Text=employee.HomePhone ;
                //txtTerminatedDate.text=employee.TerminatedDate;
                //txtHomeZipCode.Text = employee.HomeZipCode;
                ddlJobGrade.SelectedValue = employee.JobGrade;
                txtMobilePhone.Text = employee.MobilePhone;
                txtMobilePhone2.Text = employee.MobilePhone2;
                txtOfficePhone.Text = employee.OfficePhone;
                txtWorkAddress.Text = employee.WorkAddress;
                //txtWorkCityName.Text = employee.WorkCity;
                //txtWorkCityName.Text = employee.WorkCityName;
                //txtWorkCountryName.Text = employee.WorkCountryName;
                //txtWorkCountyName.Text = employee.WorkCountyName;
                //txtWorkProvinceName.Text = employee.WorkProvince;
                //txtWorkProvinceName.Text = employee.WorkProvinceName;
                int workstatus;
                ddlWorkStatus.SelectedValue = int.TryParse(employee.WorkStatus.ToString(), out workstatus) == false ? "" : workstatus.ToString();
                //txtWorkZipCode.Text = employee.WorkZipCode;

                foreach(ListItem item in lstTitle.Items)
                {
                    item.Selected = employee.Titles.Any(m => m.ID.ToStr() == item.Value);
                }

                if (employee.ReportLine!=null)
                {
                    uxEmployeeSelect.BindEmployee(employee.ReportLine.Value);
                }

                uxPositionSelect.BindPosition(employee.ID);
            }
        }

        private void InitControls()
        {
            lstTitle.DataSource = TitleService.Query(m => m.Status == 1);
            lstTitle.DataTextField = "Name";
            lstTitle.DataValueField = "ID";
            lstTitle.DataBind();
        }
    }
}