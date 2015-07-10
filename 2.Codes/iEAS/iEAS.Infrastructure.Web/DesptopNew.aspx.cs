using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using iEAS.Module;

namespace iEAS.Infrastructure.Web
{
    [System.Web.Script.Services.ScriptService]
    public partial class DesptopNew : System.Web.UI.Page
    {
        public IDesptopUCService DesptopUCService { get; set; }
        public IUserDesptopUCService UserDeptopUCService { get; set; }


        protected override void OnInit(EventArgs e)
        {     
            LoadControl();
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                 //9c5fcdba-5d32-44e2-9e59-c64f25268556

                //插入Demo数据 
                //DesptopUC w1 = new DesptopUC() { Code = "LastMsg", Desc = "最新消息", Name = "最新消息", ID = Guid.NewGuid(), UCType = "Center" };
                //DesptopUC w2 = new DesptopUC() { Code = "LastNew", Desc = "最新动态", Name = "最新动态", ID = Guid.NewGuid(), UCType = "Center" };
                //DesptopUC s1 = new DesptopUC() { Code = "Vote", Desc = "投票", Name = "投票", ID = Guid.NewGuid(), UCType = "Right" };
                //DesptopUC s2 = new DesptopUC() { Code = "Download", Desc = "下载管理", Name = "最新动态", ID = Guid.NewGuid(), UCType = "Right" };
                //DesptopUCService.Create(w1);
                //DesptopUCService.Create(w2);
                //DesptopUCService.Create(s1);
                //DesptopUCService.Create(s2);

                //初始化数据

                //UserDesptopUC uc1 = new UserDesptopUC() { DestopUCType = "Center", UCCodes = "LastMsg,LastNew", ID = Guid.NewGuid(), UserID = "9c5fcdba-5d32-44e2-9e59-c64f25268556" };
                //UserDesptopUC uc2 = new UserDesptopUC() { DestopUCType = "Center", UCCodes = "Vote,Download", ID = Guid.NewGuid(), UserID = "9c5fcdba-5d32-44e2-9e59-c64f25268556" };

                //UserDeptopUCService.Create(uc1);
                //UserDeptopUCService.Create(uc2);

            }
        }

        [WebMethod]
        public static string UpdateUserDesptopUC(string leftCodes, string rightCodes)
        {
            try
            {
                string currUserGUI = AccountContext.Current.User.ID.ToStr();
                if (!string.IsNullOrEmpty(currUserGUI))
                {
                    IUserDesptopUCService service = ObjectContainer.GetService<IUserDesptopUCService>();
                    UserDesptopUC uc400 = service.Get(m => m.UserID == currUserGUI && m.DestopUCType == "Center");
                    if (uc400 != null)
                    {
                        uc400.UCCodes = leftCodes;
                        service.Update(uc400);
                    }
                    else
                    {
                        UserDesptopUC uc = new UserDesptopUC();
                        uc.UCCodes = leftCodes;
                        uc.UserID = currUserGUI;
                        uc.ID = Guid.NewGuid();
                        uc.DestopUCType = "Center";
                        service.Create(uc);
                    }

                    UserDesptopUC uc100 = service.Get(m => m.UserID == currUserGUI && m.DestopUCType == "Right");
                    if (uc100 != null)
                    {
                        uc100.UCCodes = rightCodes;
                        service.Update(uc100);
                    }
                    else
                    {
                        UserDesptopUC uc = new UserDesptopUC();
                        uc.UCCodes = rightCodes;
                        uc.UserID = currUserGUI;
                        uc.ID = Guid.NewGuid();
                        uc.DestopUCType = "Right";
                        service.Create(uc);
                    }
                }
                return "1";
            }
            catch (Exception)
            {
                return "0";
            }
        }
     

        private void LoadControl()
        {
            phColumnbig.Controls.Clear();
            string currUserGUI = AccountContext.Current.User.ID.ToStr();
            UserDesptopUC list400 = UserDeptopUCService.Get(m => m.UserID == currUserGUI && m.DestopUCType == "Center");
            string C2 = "LastNew,LastMsg";
            //宽的
            if (list400 != null)
            {
                C2 = list400.UCCodes;        
            }
            LoadCtlByCodes(C2, phColumnbig);



            //窄的
            UserDesptopUC UC100 = UserDeptopUCService.Get(m => m.UserID == currUserGUI && m.DestopUCType == "Right");
            string C3 = "Vote,Download";
            if (UC100!=null)
            {
                C3 = UC100.UCCodes;
            }
            LoadCtlByCodes(C3, phColumn);
        }
        
        /// 载入控件辅助方法
        /// <summary>
        /// 载入控件辅助方法
        /// </summary>
        /// <param name="codes"></param>
        /// <param name="ph"></param>
        private void LoadCtlByCodes(string codes,PlaceHolder ph)
        {
            codes.Split(',').ToList().ForEach(code =>
            {
                if (!string.IsNullOrEmpty(code))
                {
                    Control ctl = Page.LoadControl("~/Pages/Desptop/UserControl/" + code + ".ascx");
                    if (ctl != null)
                    {
                        ph.Controls.Add(ctl);
                    }
                }
            });
        }
    }
}