using iEAS.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iEAS.Infrastructure.Web
{
    public partial class _Portal : System.Web.UI.Page
    {
        private PortalInfo _PortalInfo;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private IEnumerable<iEAS.Module.Menu> _TopMenus;
        public IEnumerable<iEAS.Module.Menu> TopMenus
        {
            get
            {
                if(_TopMenus==null)
                {
                    _TopMenus = AccountContext.Current.GetPortalMenus(PortalCode)
                        .Where(m=>m.ParentID==null)
                        .OrderBy(m => m.Sort);
                }
                return _TopMenus;
            }
        }

        public string PortalCode
        {
            get { return Request["code"].ToStr("Default"); }
        }

        public string GetRoleListStr()
        {
            var lstRole=AccountContext.Current.Roles.Select(m => m.Name).ToList();
            if(AccountContext.Current.IsAdministrator)
            {
                lstRole.Insert(0,"超级管理员");
            }
            return lstRole.Count == 0 ? String.Empty : "[" + String.Join(",", lstRole.ToArray()) + "]";
        }
    }
}