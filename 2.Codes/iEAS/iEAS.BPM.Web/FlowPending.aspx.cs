using iEAS.BPM.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iEAS.BPM.Web
{
    public partial class FlowPending : System.Web.UI.Page
    {
        public static string connString = "http://localhost:8733/BPMService/";

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //BindData();
            }
        }

        private void BindData()
        {
            using (Connection conn = new Connection(connString))
            {
                conn.ImpersonateUser(txtUser.Text.Trim());
                conn.Open();
                gvList.DataSource = conn.OpenWorklist();
                gvList.DataBind();
            }
            
        }

        protected void gvList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName=="Approve")
            {
                string sn = e.CommandArgument + "";
                using (Connection conn = new Connection(connString))
                {
                    conn.ImpersonateUser(txtUser.Text.Trim());
                    conn.Open();
                    var worklistItem=conn.OpenWorklistItem(sn);
                    worklistItem.Execute();
                }
                BindData();
            }
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void btnCreateTest_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/FlowSubmit.aspx");
        }
    }
}