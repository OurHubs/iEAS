using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace iEAS.Web.UI
{
    public class ListView : System.Web.UI.WebControls.ListView
    {
        public ListView()
        {
           
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }

        public void ReBindData()
        {
            IPageableItemContainer container = this as IPageableItemContainer;
            container.SetPageProperties(this.StartRowIndex, this.MaximumRows, true);
        }
    }
}
