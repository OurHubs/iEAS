using iEAS.Account;
using iEAS.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Menu = iEAS.Module.Menu;

namespace iEAS.Infrastructure.Web.Pages.Module
{
    public partial class MenuAuthorization : System.Web.UI.Page
    {
        public IPermissionService PermissionService { get; set; }

        public IPortalService PortalService { get; set; }

        public IMenuService MenuService { get; set; }

        private IList<PortalInfo> _Portals;
        public IList<PortalInfo> Portals
        {
            get
            {
                if(_Portals==null)
                {
                    _Portals = PortalService.Query(null,o => o.Asc(m => m.ID));
                }
                return _Portals;
            }
        }

        public Guid CurrentPortalGuid
        {
            get
            {
                if(ViewState["CurrentPortalGuid"]==null)
                {
                    var portal=Portals.FirstOrDefault();
                    if (portal == null)
                        throw new BusinessException("没有可用的Portal");
                    ViewState["CurrentPortalGuid"]=portal.Guid;
                }
                return (Guid)ViewState["CurrentPortalGuid"];
            }
            set
            {
                ViewState["CurrentPortalGuid"]=value;
            }
        }

        public string OwnerGuid 
        {
            get
            {
                string guid = Request["OwnerGuid"];
                if(String.IsNullOrEmpty(guid))
                {
                    throw new BusinessException("OwnerGuid不能为空！");
                }
                return guid;
            }
        }

        public string OwnerType
        {
            get
            {
                string ownerType = Request["OwnerType"];
                if (String.IsNullOrEmpty(ownerType))
                {
                    throw new BusinessException("OwnerType不能为空！");
                }
                return ownerType;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindControls();
            }
        }

        protected void rptPortal_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            CurrentPortalGuid = e.CommandArgument.ToString().ToGuid();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var checkMenus = hfSelectedMenus.Value.Trim(',');
            string[] ids = new string[0];
            if (!String.IsNullOrEmpty(checkMenus))
            {
                ids = checkMenus.Split(',');
            }

            var menuIds = MenuService.Query(m => m.Portal.Guid == CurrentPortalGuid).Select(m => m.Guid.ToString());

            PermissionService.SavePermissions(OwnerType, OwnerGuid, "MENU", ids,menuIds);
        }

        private void BindControls()
        {
            BindProtal();
        }
        private void BindProtal()
        {
            rptPortal.DataSource = Portals;
            rptPortal.DataBind();
        }

        public string BuildMenuData()
        {
            var allMenus = MenuService.Query(m => m.Portal.Guid == CurrentPortalGuid && m.Status == 1, o => o.Asc(m => m.ID));
            var selectedMenus = PermissionService.GetPermissions(OwnerType, OwnerGuid, "MENU");

            StringBuilder sbMenuData = new StringBuilder();
            sbMenuData.Append("[");

            foreach(var item in allMenus)
            {
                sbMenuData.AppendFormat("{{id:{0},pId:{1},name:'{2}',guid:'{3}',open:true,checked:{4}}},", item.ID, item.ParentID.ToStr("null"), item.Name, item.Guid, selectedMenus.Any(m=>m.ResouceID==item.Guid.ToString())?"true":"false");
            }
            sbMenuData.Trim(',').Append(']');
            hfSelectedMenus.Value = String.Join(",", selectedMenus.Select(m => m.ResouceID).ToArray());
            return sbMenuData.ToString();
        }
    }
}