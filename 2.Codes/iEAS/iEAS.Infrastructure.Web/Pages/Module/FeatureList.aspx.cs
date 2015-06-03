using iEAS.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iEAS.Infrastructure.Web.Pages.Module
{
    public partial class FeatureList : System.Web.UI.Page
    {
        public IFeatureService FeatureService { get; set; }

        public int ModuleID
        {
            get
            {
                int? moduleID = Request["moduleID"].ToNInt();
                if (moduleID == null)
                {
                    throw new BusinessException("ModuleID不能为空！");
                }
                return moduleID.Value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected IPageableDataSource odsQuery_Query(object sender, iEAS.Web.UI.ObjectDataSourceEventArgs args)
        {
            var result = FeatureService.QueryRecord(m => m.ModuleID == ModuleID && m.Status == 1,
                                                        o => o.Asc(m => m.ID),
                                                        args.startRowIndex,
                                                        args.maxRows, true);
            List<Feature> records = new List<Feature>();
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

            return new QueryResult<Feature>
            {
                Items = records,
                RecordCount = result.RecordCount
            };
        }

        protected void lvQuery_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                int rid = e.CommandArgument.ToString().ToInt();
                FeatureService.DeleteByID(rid);
                lvQuery.DataBind();
            }
        }

        private void BuildItems(Feature item, List<Feature> records, string prefix)
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