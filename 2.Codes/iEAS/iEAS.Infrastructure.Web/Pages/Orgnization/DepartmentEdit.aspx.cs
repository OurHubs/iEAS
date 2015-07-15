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
        public ICompanyService CompanyService { get; set; }

        public IPositionService PositionService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitControls();
                BindData();
            }
        }

        public Guid? CompanyID
        {
            get
            {
                return HttpHelper.RequestValue("companyId").ToNGuid();
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
            try
            {
                using (var ctx = DepartmentService.BeginContext())
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

                    List<Guid> positionIds = new List<Guid>();
                    foreach (ListItem item in lstPosition.Items)
                    {
                        if (item.Selected)
                        {
                            positionIds.Add(item.Value.ToGuid());
                        }
                    }

                    PositionService.JoinContext(ctx);

                    department.Positions.Clear();
                    var pids = positionIds.ToArray();
                    var positions = PositionService.Query(m => pids.Contains(m.ID));
                    department.Positions.AddRange(positions);


                    DepartmentService.CreateOrUpdate(department);
                    ctx.Commit();
                }
            }
            catch (Exception ex)
            {
                LogManager.GetLogger().Error("保存部门信息出错！", ex);
                throw ex;
            }
            Response.Redirect("DepartmentList.aspx?companyID=" + CompanyID);
        }

        private void BindData()
        {
            var department = DepartmentService.GetByID(RecordID,true);
            if (department != null)
            {
                txtName.Text = department.Name;
                txtCode.Text = department.Code;
                txtDesc.Text = department.Desc;
                txtDeputyNumber.Text = department.DeputyNumber;
                txtPrincipalNumber.Text = department.PrincipalNumber;
                lblCompany.Text = department.Company.Name;

                foreach(ListItem item in lstPosition.Items)
                {
                    item.Selected=department.Positions.Any(m=>m.ID.ToStr()==item.Value);
                }
            }
            lblParent.Text = "（无）";
            if (ParentID.HasValue)
            {
                Department parent = DepartmentService.GetByID(ParentID.Value, true);
                if (parent != null)
                {
                    lblParent.Text = parent.Name;
                }
            }
            if(department==null && CompanyID!=null)
            {
                Company company = CompanyService.GetByID(CompanyID.Value);
                lblCompany.Text = company.Name;
            }
        }

        private void InitControls()
        {
            lstPosition.DataSource=PositionService.QueryAll();
            lstPosition.DataTextField = "Name";
            lstPosition.DataValueField = "ID";
            lstPosition.DataBind();
        }
    }
}