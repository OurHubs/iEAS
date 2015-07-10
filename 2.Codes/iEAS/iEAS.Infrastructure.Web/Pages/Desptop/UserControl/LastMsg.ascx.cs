using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iEAS.Module;


namespace iEAS.Infrastructure.Web.Pages.Destptop.UserControl
{
    public partial class LastMsg : System.Web.UI.UserControl
    {
        public IDesptopUCService DesptopUCService { get; set; }
        public IUserDesptopUCService UserDeptopUCService { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //string currUserGUI = AccountContext.Current.User.Guid.ToStr();
                //List<UserDesptopUC> list400 = UserDeptopUCService.Query(m => m.UserGUI == currUserGUI && m.DestopUCType == "400").ToList();
                //List<UserDesptopUC> list100 = UserDeptopUCService.Query(m => m.UserGUI == currUserGUI && m.DestopUCType == "100"&&m).ToList();


            }
        }
    }
}