using iEAS.Account;
using iEAS.Infrastructure.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

namespace iEAS.Infrastructure.Web.Pages.Account
{
    [System.Web.Script.Services.ScriptService]
    public partial class RoleEdit : EditForm
    {
        public IRoleService RoleService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var role = RoleService.GetByID(RecordID);

            if (role == null)
            {
                role = new Role();
            }

            role.Name = txtName.Text.Trim();
            role.Code = txtCode.Text.Trim();
            role.Desc = txtDesc.Text.Trim();
            role.Status = 1;

            try
            {
                RoleService.CreateOrUpdate(role);
            }
            catch (Exception ex)
            {
                LogManager.GetLogger().Error("保存角色信息出错！", ex);
                throw ex;
            }
            Response.Redirect("RoleList.aspx");
        }

        private void BindData()
        {
            var role = RoleService.GetByID(RecordID);
            if (role != null)
            {
                txtName.Text = role.Name;
                txtCode.Text = role.Code;
                txtDesc.Text = role.Desc;
            }
        }


        [WebMethod]
        public static string CheckRoleCode(string roleCode)
        {
            return "1";
        }
    }
}