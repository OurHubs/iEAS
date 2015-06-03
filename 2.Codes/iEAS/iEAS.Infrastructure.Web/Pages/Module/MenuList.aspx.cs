using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iEAS.Module;


namespace iEAS.Infrastructure.Web.Pages.Module
{
    public partial class MenuList : System.Web.UI.Page
    {
        public IMenuService MenuService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected IPageableDataSource odsQuery_Query(object sender, iEAS.Web.UI.ObjectDataSourceEventArgs args)
        {
            var result= MenuService.QueryRecord(m => m.Status == 1 
                                           && m.PortalID == PortalID.Value,
                                                        o => o.Asc(m => m.ID),
                                                        args.startRowIndex,
                                                        args.maxRows,true);

            List<iEAS.Module.Menu> records = new List<iEAS.Module.Menu>();
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

            return new QueryResult<iEAS.Module.Menu>
            {
                Items = records,
                RecordCount = result.RecordCount
            };
        }

        private void BuildItems(iEAS.Module.Menu item, List<iEAS.Module.Menu> records, string prefix)
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


        protected void lvQuery_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                int rid = e.CommandArgument.ToString().ToInt();
                MenuService.DeleteByID(rid);
                lvQuery.DataBind();
            }
        }

        //入口
        public int? PortalID
        {
            get
            {
                return Request["portalid"].ToInt(0);
            }
        }
    }
}