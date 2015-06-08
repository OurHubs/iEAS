using iEAS.Account;
using iEAS.BaseData;
using iEAS.Module;
using iEAS.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iEAS.Infrastructure.Web
{

    public class DatabaseInitializer : DropCreateDatabaseAlways<iEASRepository>
    {
        protected override void Seed(iEASRepository context)
        {
            base.Seed(context);

            #region 添加

            var user = new User
            {
                LoginName = "admin",
                Password = "admin",
                Name = "admin",
                Status = 1,
                Guid = "bb62d704-01f2-4187-9c32-9c2c7670940e".ToGuid()
            };

            context.Users.Add(user);


            var role = new Role
            {
                Name = "管理员",
                Code = "Administrator",
                Status = 1
            };
            context.Roles.Add(role);
            user.Roles.Add(role);
            context.SaveChanges();

            var portal = new PortalInfo
            {
                Code = "Default",
                Name = "默认",
                Status=1
            };

            context.PortalInfos.Add(portal);

            portal.Menus.Add(new iEAS.Module.Menu
            {
                Name = "系统设置",
                Status=1,
                Children = new List<Module.Menu>
                 {
                      new Module.Menu{ Name="基础数据管理", Url="~/Pages/BaseData/BaseDataTypeList.aspx",Status=1},
                     new Module.Menu{ Name="用户管理", Url="~/Pages/Account/UserList.aspx",Status=1},
                      new Module.Menu{ Name="角色管理", Url="~/Pages/Account/RoleList.aspx",Status=1},
                       new Module.Menu{ Name="Portal管理", Url="~/Pages/Module/PortalList.aspx",Status=1},
                        new Module.Menu{ Name="模块管理", Url="~/Pages/Module/ModuleList.aspx",Status=1},

                 }
            });

            context.SaveChanges();


            #endregion
        }
    }

    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGenerateDB_Click(object sender, EventArgs e)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<FrameworkRepository>());
            Database.SetInitializer(new DatabaseInitializer());
            using (var rep = new FrameworkRepository())
            {
                rep.Database.Initialize(true);
            }
            using (var rep = new iEASRepository())
            {
                rep.Database.Initialize(true);
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            using (var rep = ObjectContainer.GetOwnedService<iEASRepository>())
            {
                var dataType = new BaseDataType
                {
                    Name = "1111",
                    Code = "1111",
                    Status=1,
                    Items = new List<BaseDataItem>
                {
                    new BaseDataItem{ Name="aaaa",Value="aaaa",Status=1},
                    new BaseDataItem{ Name="aaaa",Value="aaaa",Status=1},
                    new BaseDataItem{ Name="aaaa",Value="aaaa",Status=1},
                    new BaseDataItem{ Name="aaaa",Value="aaaa",Status=1},
                    new BaseDataItem{ Name="aaaa",Value="aaaa",Status=1},
                    new BaseDataItem{ Name="aaaa",Value="aaaa",Status=1},
                }
                };
                rep.Create(dataType);
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            SessionContext.Current.RegisterUserID("bb62d704-01f2-4187-9c32-9c2c7670940e".ToGuid());
            SessionContext.Current.RegisterPortal("Default");
            Response.Redirect("~/Default.aspx");
        }
    }
}