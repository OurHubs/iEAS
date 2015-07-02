using iEAS.Model.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iEAS.Infrastructure.Web.Model.Controls.Form
{
    public partial class UxForm : System.Web.UI.UserControl
    {
        protected override void OnInit(EventArgs e)
        {
            plForm.Controls.Clear();
            Control ctr = this.LoadControl("~/_Templates/Default/Model/LXGLBF.ascx");
            plForm.Controls.Add(ctr);
            BindData();
            base.OnInit(e);
        }


        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void BindData()
        {
            foreach(var container in ModelFieldRegistry.Current.Fields)
            {
                container.BindField(null);
            }
        }
    }
}