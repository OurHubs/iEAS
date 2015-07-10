using iEAS.Infrastructure.UI;
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
    public partial class DepartmentEdit : EditForm
    {
        public IDepartmentService DepartmentService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        public Guid CompanyID
        {
            get
            {
                return HttpHelper.RequestValue("companyId").ToGuid();
            }
        }

        public Guid? ParentID
        {
            get
            {
                return Request["parentID"].ToNGuid();
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            var department = DepartmentService.GetByID(RecordID);

            if (department == null)
            {
                department = new Department();
                department.CompanyID = CompanyID;
                department.ParentID = ParentID;
            }

            department.Name = txtName.Text.Trim();
            department.Code = txtCode.Text.Trim();
            department.PrincipalNumber = txtPrincipalNumber.Text.Trim();
            department.DeputyNumber = txtDeputyNumber.Text.Trim();
            department.Desc = txtDesc.Text.Trim();
            department.Status = 1;

            try
            {
                DepartmentService.CreateOrUpdate(department);
            }
            catch (Exception ex)
            {
                LogManager.GetLogger().Error("保存部门信息出错！", ex);
                throw ex;
            }
            Response.Redirect("DepartmentList.aspx");
        }

        private void BindData()
        {
            var department = DepartmentService.GetByID(RecordID);
            if (department != null)
            {
                txtName.Text = department.Name;
                txtCode.Text = department.Code;
                txtDesc.Text = department.Desc;
                txtDeputyNumber.Text = department.DeputyNumber;
                txtPrincipalNumber.Text = department.PrincipalNumber;
            }
            lblParent.Text = "顶级栏目";
            if (ParentID.HasValue)
            {
                Department parent = DepartmentService.GetByID(ParentID.Value, true);
                if (parent != null)
                {
                    lblParent.Text = parent.Name;
                }
            }
        }
    }
}