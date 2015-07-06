using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iEAS.Utility;

namespace iEAS.Infrastructure.Web.Pages.Model
{
    public partial class ModelTempEditIframe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }
        private void BindData()
        {
            if (!string.IsNullOrEmpty(Code))
            {
                string tempName = string.Format("{0}.ascx",Code);
                //取出模板html
               string tempHtml= HtmlHelper.ReadTemplate(tempName, Server.MapPath("~/Config/Model/"));
               txtTempalte.Text = tempHtml;
            }
        }

        public string Code
        {
            get { return HttpHelper.RequestValue("code"); }
        }
    }
}