using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iEAS.Web.UI
{
    public class ListView : System.Web.UI.WebControls.ListView
    {
        public ListView()
        {
            this.PagePropertiesChanging += ListView_PagePropertiesChanging;
        }

        void ListView_PagePropertiesChanging(object sender, System.Web.UI.WebControls.PagePropertiesChangingEventArgs e)
        {
            this.SetPageProperties(e.StartRowIndex, e.MaximumRows, true);
        }
    }
}
