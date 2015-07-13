using iEAS.Config;
using iEAS.Orgnization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iEAS.Infrastructure.Web.Pages.Orgnization
{
    public partial class CompanyTree : System.Web.UI.Page
    {
        public ICompanyService CompanyService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string BuildTreeNodes()
        {
            var nodes = CompanyService.Query(m => m.Status == 1, o => o.Asc(m => m.SN));

            StringBuilder sbTreeNodes = new StringBuilder();
            sbTreeNodes.Append("[");
            sbTreeNodes.AppendFormat("{{id:'{0}',pId:{1},name:'{2}',open:true,url:'{3}',target:'main'}},", Guid.Empty, "null",SiteConfig.Instance.Title, GetUrl(null));

            foreach (var node in nodes)
            {
                sbTreeNodes.AppendFormat("{{id:'{0}',pId:'{1}',name:'{2}',open:true,url:'{3}',target:'main'}},", node.ID, Guid.Empty, node.Name, GetUrl(node));
            }
            sbTreeNodes.Trim(',').Append(']');
            return sbTreeNodes.ToString();
        }

        private string GetUrl(Company node)
        {

            return node != null ? String.Format("DepartmentList.aspx?companyId={0}", node.ID) : String.Empty;
        }
    }
}