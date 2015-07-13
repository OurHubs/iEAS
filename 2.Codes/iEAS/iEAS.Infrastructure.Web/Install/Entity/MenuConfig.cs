using iEAS.Module;
using iEAS.Utility;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace iEAS.Infrastructure.Web.Install
{
    public class MenuConfig
    {
        private List<Menu> _Menus = new List<Menu>();

        public static MenuConfig GetConfig()
        {
            string path=Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Install/Config/Menu.config");
            return XmlHelper.Deserialize<MenuConfig>(path);
        }

        public void Save()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Install/Config/Menu.config");
            XmlHelper.Serialize(this, path);
        }

        public void InstallToDatabase()
        {
            IMenuService menuService = ObjectContainer.GetService<IMenuService>();
            IPortalService portalService = ObjectContainer.GetService<IPortalService>();
            var portal = portalService.Get(m => m.Code == "Default");
            using(var ctx=menuService.BeginContext())
            {
                ctx.Set<iEAS.Module.Menu>().RemoveRange(ctx.Set<iEAS.Module.Menu>());
                int index = 0;
                foreach(var menu in this.Menus)
                {
                    AddMenu(ctx.Set<iEAS.Module.Menu>(), menu, null,portal.ID,index++);
                }

                ctx.Commit();
            }
        }

        private void AddMenu(DbSet<iEAS.Module.Menu> dbset, Menu menu, iEAS.Module.Menu parent,Guid portalId,int index)
        {
            iEAS.Module.Menu m = new Module.Menu();
            m.Name = menu.Name;
            m.Code = menu.Code;
            m.PortalID = portalId;
            m.Sort = index;
            m.Status = 1;
            m.Url = menu.Url;
            if(parent!=null)
            {
                parent.Children.Add(m);
            }
            else
            {
                dbset.Add(m);
            }
            int index2 = 0;
            foreach (var item in menu.Children)
            {
                AddMenu(dbset, item, m,portalId,index2++);
            }
        }

        

        [XmlElement("Menu")]
        public List<Menu> Menus
        {
            get { return _Menus; }
            set { _Menus = value; }
        }
    }

    [Serializable]
    public class Menu
    {
        private string _ID;
        private List<Menu> _Children = new List<Menu>();

        [XmlAttribute]
        public string ID
        {
            get
            {
                if(String.IsNullOrEmpty(_ID))
                {
                    _ID = Guid.NewGuid().ToStr();
                }
                return _ID;
            }
            set{ _ID=value; }
        }
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string Code { get; set; }
        [XmlAttribute]
        public string Url { get; set; }

        
        [XmlElement("Menu")]
        public List<Menu> Children
        {
            get { return _Children; }
            set { _Children = value; }
        }
    }
}