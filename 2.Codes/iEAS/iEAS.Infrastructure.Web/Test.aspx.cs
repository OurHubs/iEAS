using iEAS.Account;
using iEAS.BaseData;
using iEAS.Model.Config;
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
                Status = 1
            };

            context.PortalInfos.Add(portal);
            context.SaveChanges();



            portal.Menus.Add(new iEAS.Module.Menu
            {
                Name = "个人桌面",
                Url = "Desktop.aspx",
                Status = 1,
                Sort = 1
            });

            context.SaveChanges();

            portal = context.Get<PortalInfo>(m => m.Guid == portal.Guid);

            portal.Menus.Add(new iEAS.Module.Menu
            {
                Name = "内容管理",
                Status = 1,
                Children = new List<Module.Menu>
                 {
                      new Module.Menu{ Name="栏目内容", Url="Pages/Module/ChannelIndex.aspx",Status=1, Sort=1,PortalID=portal.ID},
                      new Module.Menu{ Name="栏目管理", Url="Pages/Module/ChannelList.aspx",Status=1, Sort=7,PortalID=portal.ID},
                      new Module.Menu{ Name="新闻动态", Url="Model/Query/News",Status=1, Sort=7,PortalID=portal.ID},
                      new Module.Menu{ Name="用户案例", Url="Model/Query/UserCase",Status=1, Sort=7,PortalID=portal.ID},
                      new Module.Menu{ Name="单页内容", Url="Model/Query/PageContent",Status=1, Sort=7,PortalID=portal.ID},
                 },
                Sort = 2
            });
            portal.Menus.Add(new iEAS.Module.Menu
            {
                Name = "人事运营",
                Status = 1,
                Children = new List<Module.Menu>
                 {
                     new Module.Menu{ Name="基础数据管理", Url="Pages/BaseData/BaseDataTypeList.aspx",Status=1, Sort=1,PortalID=portal.ID},
                     new Module.Menu{ Name="用户管理", Url="Pages/Account/UserList.aspx",Status=1, Sort=2,PortalID=portal.ID},
                     new Module.Menu{ Name="角色管理", Url="Pages/Account/RoleList.aspx",Status=1, Sort=3,PortalID=portal.ID},
                     new Module.Menu{ Name="Portal管理", Url="Pages/Module/PortalList.aspx",Status=1, Sort=4,PortalID=portal.ID},
                     new Module.Menu{ Name="模块管理", Url="Pages/Module/ModuleList.aspx",Status=1, Sort=5,PortalID=portal.ID},
                     
                 },
                Sort = 3
            });
            portal.Menus.Add(new iEAS.Module.Menu
            {
                Name = "系统设置",
                Status = 1,
                Children = new List<Module.Menu>
                 {
                     new Module.Menu{ Name="基础数据管理", Url="Pages/BaseData/BaseDataTypeList.aspx",Sort=1,Status=1,PortalID=portal.ID},
                     new Module.Menu{ Name="用户管理", Url="Pages/Account/UserList.aspx",Sort=2,Status=1,PortalID=portal.ID},
                     new Module.Menu{ Name="角色管理", Url="Pages/Account/RoleList.aspx",Sort=3,Status=1,PortalID=portal.ID},
                     new Module.Menu{ Name="Portal管理", Url="Pages/Module/PortalList.aspx",Sort=4,Status=1,PortalID=portal.ID},
                     new Module.Menu{ Name="模块管理", Url="Pages/Module/ModuleList.aspx",Sort=5,Status=1,PortalID=portal.ID},
                     new Module.Menu{ Name="测试数据", Url="Test.aspx", Sort=6,Status=1,PortalID=portal.ID},
                     new Module.Menu{ Name="模型管理", Url="Pages/Model/ModelRegistryList.aspx", Sort=7,Status=1,PortalID=portal.ID},
                 },
                Sort = 4
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
                    Status = 1,
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
            AccountContext.Current.RegisterUserID("bb62d704-01f2-4187-9c32-9c2c7670940e".ToGuid());
            Response.Redirect("~/Default.aspx");
        }

        protected void btnSaveModelFile_Click(object sender, EventArgs e)
        {
            ModelConfig config = new ModelConfig();
            config.Code = "Test";
            config.Name = "测试模型";


            ModelForm form = new ModelForm();
            form.Code = "测试表单";
            form.Template = "TowColumns";
            form.Fields.Add(new ModelField
            {
                Code = "1",
                Control = "2",
                Title = "T",
                IgnoreNullOrEmpty = true

            });
            form.Groups.Add(new ModelGroup
            {
                Fields = new ModelFieldCollection(),
                Forms = new ModelSubFormCollection()
            });
            form.Params.Add(new ModelParam
            {
                Value = "1",
                Name = "2",
                Content = "C"
            });
            config.Forms.Add(form);

            config.Lists.Add(new ModelList
            {
                Code = "111",
                Columns = new ModelColumnCollection{
                      new ModelColumn{ Code="12", Title="223"}
                  }
            });

            config.Tables.Add(new ModelTable
            {
                Code = "c",
                Name = "N",
                Columns = new ModelTableColumnCollection
                {
                    new ModelTableColumn()
                }
            });

            config.Save();
        }

        protected void btnModelEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Model/ModelEdit.aspx?model=Article");
        }

        protected void btnModelQuery_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Model/ModelQuery.aspx?model=Article");
        }

        protected void btnModelRegistry_Click(object sender, EventArgs e)
        {
            ModelRegistryCollection regs = new ModelRegistryCollection();
            regs.Add(new ModelRegistry { Name = "1", Desc = "d", Module = "M", Path = "Article.xml" });
            regs.Save();
        }
    }
}