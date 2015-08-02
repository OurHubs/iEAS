using iEAS.BPM.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iEAS.BPM.Web
{
    public partial class FlowSubmit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            using (Connection conn = new Connection(FlowPending.connString))
            {
                conn.Open();
                conn.ImpersonateUser(txtUser.Text.Trim());
                var instance=conn.CreateProcessInstance(ddlProcess.SelectedValue);
                instance.Folio = txtFolio.Text.Trim();
                instance.Submit();
            }
            Response.Redirect("~/FlowPending.aspx");
        }
    }
}