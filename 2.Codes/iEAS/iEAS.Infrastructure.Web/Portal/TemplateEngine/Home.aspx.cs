using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iEAS.Infrastructure.Web.Portal.TemplateEngine
{
    public partial class Home : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            LoadTempalte();
            base.OnInit(e);
        }
        private void LoadTempalte()
        {
            var template = Page.LoadControl("~/_Templates/Default/Home.ascx");
            this.Controls.Clear();
            this.Controls.Add(template);
        }
    }
}