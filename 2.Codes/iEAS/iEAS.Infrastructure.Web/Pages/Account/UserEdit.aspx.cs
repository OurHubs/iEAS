using iEAS.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iEAS.Infrastructure.Web.Pages.Account
{
    public partial class UserEdit : System.Web.UI.Page
    {
        public IUserService UserService { get; set; }

        public IRoleService RoleService { get; set; }

        public int RecordID
        {
            get { return Request["rid"].ToInt(0); }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var userService = ObjectContainer.GetService<IUserService>();
            var roleService = ObjectContainer.GetService<IRoleService>();

            using (var ctx = userService.BeginContext())
            {
                roleService.JoinContext(ctx);

                var user = userService.GetByID(RecordID);
                if (user == null)
                {
                    user = new User();
                }
                user.LoginName = txtLoginName.Text.Trim();
                user.Password = txtPassword.Text.Trim();
                user.Name = txtName.Text.Trim();
                user.Nick = txtNick.Text.Trim();
                user.Gender = rblGender.SelectedValue.ToNInt();
                user.Birthday = txtBirthday.Text.Trim().ToNDateTime();
                user.Telephone = txtTelephone.Text.Trim();
                user.Email = txtEmail.Text.Trim();
                user.HomeZip = txtHomeZip.Text.Trim();
                user.HomeAddress = txtHomeAddress.Text.Trim();
                user.WorkZip = txtWorkZip.Text.Trim();
                user.WorkAddress = txtWorkAddress.Text.Trim();
                user.Status = 1;

                try
                {
                    user.Roles.Clear();
                    var roleIds = uxRoleSelect.GetRoleIds();
                    user.Roles = roleService.Query(m => roleIds.Contains(m.ID)).ToList();
                    userService.CreateOrUpdate(user);
                }
                catch (Exception ex)
                {
                    LogManager.GetLogger().Error("保存用户信息出错！", ex);
                    throw ex;
                }
                ctx.Commit();
            }
            Response.Redirect("UserList.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserList.aspx");
        }

        private void BindData()
        {
            var user = UserService.GetByID(RecordID,true);
            if (user != null)
            {
                txtLoginName.Text = user.LoginName;
                txtPassword.Text = user.Password;
                txtName.Text = user.Name;
                txtNick.Text = user.Nick;
                rblGender.SelectedValue = user.Gender + "";
                txtBirthday.Text = user.Birthday.ToStr("yyyy-MM-dd");
                txtTelephone.Text = user.Telephone;
                txtEmail.Text = user.Email;
                txtHomeZip.Text = user.HomeZip;
                txtHomeAddress.Text = user.HomeAddress;
                txtWorkZip.Text = user.WorkZip;
                txtWorkAddress.Text = user.WorkAddress;
                uxRoleSelect.BindRoles(user.Roles);
            }
            else
            {
                uxRoleSelect.BindRoles(new List<Role>());
            }
        }
    }
}