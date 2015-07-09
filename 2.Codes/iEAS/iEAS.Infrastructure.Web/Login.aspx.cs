using iEAS.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iEAS.Infrastructure.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            IUserService userService=ObjectContainer.GetService<IUserService>();

            string userName = txtUserName.Text.Trim();
            string password = txtPassword.Text.Trim();

            User user=userService.Get(m=>m.LoginName==userName);
            if(user==null)
            {
                ScriptHelper.Alert("当前帐号不存在！");
            }
            else if(user.Password!=password)
            {
                ScriptHelper.Alert("密码不正不确！");
            }
            else
            {
                AccountContext.Current.RegisterUserID(user.ID);
                Response.Redirect("~/Portal.aspx");
            }
        }
    }
}