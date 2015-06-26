using iEAS.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iEAS.Infrastructure.Web
{
    public partial class Portal : System.Web.UI.Page
    {
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
                    _TopMenus = SessionContext.Current.Menus.Where(m => m.ParentID == null).OrderBy(m => m.Sort);
                }
                return _TopMenus;
            }
        }
    }
}