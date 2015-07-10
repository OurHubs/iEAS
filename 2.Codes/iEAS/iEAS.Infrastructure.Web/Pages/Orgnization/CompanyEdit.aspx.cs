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
    public partial class CompanyEdit : EditForm
    {
        public ICompanyService CompanyService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var company = CompanyService.GetByID(RecordID);

            if (company == null)
            {
                company = new Company();
            }

            company.Name = txtName.Text.Trim();
            company.Code = txtCode.Text.Trim();
            company.Address = txtAddress.Text.Trim();
            company.WebUrl = txtWebUrl.Text.Trim();
            company.Desc = txtDesc.Text.Trim();
            company.Status = 1;

            try
            {
                CompanyService.CreateOrUpdate(company);
            }
            catch (Exception ex)
            {
                LogManager.GetLogger().Error("保存出错！", ex);
                throw ex;
            }
            Response.Redirect("CompanyList.aspx");
        }

        private void BindData()
        {
            var company = CompanyService.GetByID(RecordID);
            if (company != null)
            {
                txtName.Text = company.Name;
                txtCode.Text = company.Code;
                txtAddress.Text = company.Address;
                txtWebUrl.Text = company.WebUrl;
                txtDesc.Text = company.Desc;
            }
        }
    }
}