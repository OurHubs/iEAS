using iEAS.Account;
using iEAS.Infrastructure.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iEAS.Infrastructure.Web.Pages.Account
{
    public partial class UserEdit : EditForm
    {
        public IUserService UserService { get; set; }

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
            var userService = ObjectContainer.GetService<IUserService>();
            var roleService = ObjectContainer.GetService<IRoleService>();

            using (var ctx = userService.BeginContext())
            {
                roleService.JoinContext(ctx);

                var user = userService.GetByID(RecordID);
                if (user == null)
                {
                    user = new User();
                    //验证登录账号
                    if (IsExistLoginName(txtLoginName.Text.Trim()))
                    {
                        ScriptHelper.Alert("该账号已经存在！");
                        return;
                    }
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
            if (RoleId.HasValue)
            {
                Response.Redirect("UserRoles.aspx?roleid=" + RoleId.Value);
            }
            else
            {
                Response.Redirect("UserList.aspx");
            }
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
                txtLoginName.Enabled = false;
                txtLoginName.Text = user.LoginName;           
                this.txtPassword.Attributes["value"]=user.Password;
                txtName.Text = user.Name;
                txtNick.Text = user.Nick;
                rblGender.SelectedValue = user.Gender + "";
                txtBirthday.Text = user.Birthday.HasValue?user.Birthday.Value.ToString("yyyy-MM-dd"):"";
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
                List<Role> role = new List<Role>();
                if (RoleId.HasValue)
                {
                    role.Add(new Role { ID = RoleId.Value });
                }
                uxRoleSelect.BindRoles(role);
            }
        }

        private bool IsExistLoginName(string loginName)
        {
            if (string.IsNullOrEmpty(loginName))
            {
                return false;
            }
            IList<User> listUser = UserService.Query(m => m.LoginName== loginName);
            return (listUser != null && listUser.Count > 1);
        }

        public Guid? RoleId
        {
            get
            {
                if (Request["roleid"]!=null)
                {
                    return Request["roleid"].ToGuid();
                }
                return null;
            }
        }
    }
}