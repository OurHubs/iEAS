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
                //DesptopUC w1 = new DesptopUC() { Code = "LastMsg", Desc = "最新消息", Name = "最新消息", Guid = Guid.NewGuid(), UCType = "400" };
                //DesptopUC w2 = new DesptopUC() { Code = "LastNew", Desc = "最新动态", Name = "最新动态", Guid = Guid.NewGuid(), UCType = "400" };
                //DesptopUC s1 = new DesptopUC() { Code = "Vote", Desc = "投票", Name = "投票", Guid = Guid.NewGuid(), UCType = "100" };
                //DesptopUC s2 = new DesptopUC() { Code = "Download", Desc = "下载管理", Name = "最新动态", Guid = Guid.NewGuid(), UCType = "100" };
                //DesptopUCService.Create(w1);
                //DesptopUCService.Create(w2);
                //DesptopUCService.Create(s1);
                //DesptopUCService.Create(s2);

                //初始化数据

                //UserDesptopUC uc1=new UserDesptopUC(){ DestopUCType="400", UCCodes="LastMsg,LastNew", Guid=Guid.NewGuid(), UserGUI="bb62d704-01f2-4187-9c32-9c2c7670940e"};
                //UserDesptopUC uc2=new UserDesptopUC(){ DestopUCType="400", UCCodes="Vote,Download", Guid=Guid.NewGuid(), UserGUI="bb62d704-01f2-4187-9c32-9c2c7670940e"};

                //UserDeptopUCService.Create(uc1);
                //UserDeptopUCService.Create(uc2);

            }
        }

        [WebMethod]
        public static string UpdateUserDesptopUC(string leftCodes,string rightCodes)
        {
            try
            {
                string currUserGUI = AccountContext.Current.User.ID.ToStr();
                if (!string.IsNullOrEmpty(currUserGUI))
                {
                    IUserDesptopUCService service = ObjectContainer.GetService<IUserDesptopUCService>();
                    UserDesptopUC uc400 = service.Get(m => m.UserID == currUserGUI && m.DestopUCType == "400");
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
                        uc.DestopUCType = "400";
                        service.Create(uc400);
                    }

                    UserDesptopUC uc100 = service.Get(m => m.UserID == currUserGUI && m.DestopUCType == "100");
                    if (uc100 != null)
                    {
                        uc100.UCCodes = rightCodes;
                        service.Update(uc100);
                    }
                    else
                    {
                        UserDesptopUC uc = new UserDesptopUC();
                        uc.UCCodes = leftCodes;
                        uc.UserID = currUserGUI;
                        uc.ID = Guid.NewGuid();
                        uc.DestopUCType = "100";
                        service.Create(uc400);
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
            UserDesptopUC list400 = UserDeptopUCService.Get(m => m.UserID == currUserGUI && m.DestopUCType == "400");
            //宽的
            if (list400!=null)
            {
                list400.UCCodes.Split(',').ToList().ForEach(code =>
                {
                    if (!string.IsNullOrEmpty(code))
                    {
                        Control ctl = Page.LoadControl("~/Pages/Module/DesptopUC/" + code + ".ascx");
                        if (ctl != null)
                        {
                            phColumnbig.Controls.Add(ctl);
                        }
                    }
                });
            }

            //窄的
            UserDesptopUC UC100 = UserDeptopUCService.Get(m => m.UserID == currUserGUI && m.DestopUCType == "100");
            if (UC100!=null)
            {
                 UC100.UCCodes.Split(',').ToList().ForEach(code =>
                {
                    if (!string.IsNullOrEmpty(code))
                    {
                        Control ctl = Page.LoadControl("~/Pages/Module/DesptopUC/" + code + ".ascx");
                        if (ctl != null)
                        {
                            phColumn.Controls.Add(ctl);
                        } 
                    }
                   
                });
            }


        }
    }
}