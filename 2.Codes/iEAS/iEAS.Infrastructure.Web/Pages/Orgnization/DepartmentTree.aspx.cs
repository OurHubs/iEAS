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
    public partial class DepartmentTree : System.Web.UI.Page
    {

        public ICompanyService CompanyService { get; set; }
        public IDepartmentService DepartmentService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string BuildTreeNodes()
        {
            var companies = CompanyService.Query(m => m.Status == 1, o => o.Asc(m => m.SN));
            var departments = DepartmentService.Query(m => m.Company.Status==1 && m.Status == 1, o => o.Asc(m => m.SN));

            StringBuilder sbTreeNodes = new StringBuilder();
            sbTreeNodes.Append("[");
            sbTreeNodes.AppendFormat("{{id:'{0}',pId:{1},name:'{2}',open:true,url:'EmployeeList.aspx',target:'main'}},", Guid.Empty, "null", SiteConfig.Instance.Title, String.Empty);

            foreach(var company in companies)
            {
                sbTreeNodes.AppendFormat("{{id:'{0}',pId:'{1}',name:'{2}',open:true,url:'{3}',target:'main'}},", company.ID, Guid.Empty, company.Name, GetUrl(company));
            }

            foreach (var department in departments)
            {
                if (department.ParentID == null)
                {
                    sbTreeNodes.AppendFormat("{{id:'{0}',pId:'{1}',name:'{2}',open:true,url:'{3}',target:'main'}},", department.ID,department.CompanyID, department.Name, GetUrl(department));
                }
                else
                {
                    sbTreeNodes.AppendFormat("{{id:'{0}',pId:'{1}',name:'{2}',open:true,url:'{3}',target:'main'}},", department.ID, department.ParentID, department.Name, GetUrl(department));
                }
            }
            sbTreeNodes.Trim(',').Append(']');
            return sbTreeNodes.ToString();
        }

        private string GetUrl(Company node)
        {
            return node != null ? String.Format("EmployeeList.aspx?companyId={0}", node.ID) : String.Empty;
        }
        private string GetUrl(Department node)
        {
            return node != null ? String.Format("EmployeeList.aspx?departmentId={0}", node.ID) : String.Empty;
        }
    }
}