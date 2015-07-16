using iEAS.Infrastructure.UI;
using iEAS.Orgnization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iEAS.Infrastructure.Web.Pages.Controls.Pages
{
    public partial class DepartmentSelect : ListForm
    {
        public IDepartmentService DepartmentService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        public Guid CompanyID
        {
            get
            {
                Guid? companyID = "6ff3c2ff-dbcb-4e21-90e5-53aafd16d579".ToNGuid();
                if (companyID == null)
                {
                    throw new BusinessException("公司ID不能为空！");
                }
                return companyID.Value;
            }
        }
        private void BindData()
        {
            var result = DepartmentService.Query(m => m.CompanyID == CompanyID && m.Status == 1, null, true);

            List<Department> records = new List<Department>();
            var roots = result.Where(m => m.ParentID == null).ToList();

            for (int i = 0; i < roots.Count; i++)
            {
                var item = roots[i];
                records.Add(item);

                if (i == roots.Count - 1)
                {
                    item.Name = "└─" + item.Name;
                    BuildItems(item, records, "　　");
                }
                else
                {
                    item.Name = "├─" + item.Name;
                    BuildItems(item, records, "│　");
                }
            }

            gvList.DataSource = records;
            gvList.DataBind();
        }

        private void BuildItems(Department item, List<Department> records, string prefix)
        {
            if (item.Children == null)
                return;
            var items = item.Children.Where(m => m.Status == 1).ToArray();
            for (int i = 0; i < items.Length; i++)
            {
                var subItem = items[i];
                string subPrefix = prefix;
                if (i == items.Length - 1)
                {
                    subItem.Name = prefix + "└─" + subItem.Name;
                    subPrefix = prefix + "　　";
                }
                else
                {
                    subItem.Name = prefix + "├─" + subItem.Name;
                    subPrefix = prefix + "│　";
                }
                records.Add(subItem);
                BuildItems(subItem, records, subPrefix);
            }
        }
    }
}