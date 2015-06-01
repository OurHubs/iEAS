using iEAS.BaseData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iEAS.Infrastructure.Web.Pages.BaseData
{
    public partial class BaseDataItemList : System.Web.UI.Page
    {
        public IBaseDataItemService BaseDataItemService { get; set; }

        public int TypeID
        {
            get
            {
                int? typeID = Request["typeid"].ToNInt();
                if (typeID == null)
                {
                    throw new BusinessException("类型ID不能为空！");
                }
                return typeID.Value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected IPageableDataSource odsQuery_Query(object sender, iEAS.Web.UI.ObjectDataSourceEventArgs args)
        {
            var result= BaseDataItemService.QueryRecord(m => m.TypeID==TypeID && m.Status==1,
                                                        o => o.Asc(m => m.ID),
                                                        args.startRowIndex,
                                                        args.maxRows,true);
            List<BaseDataItem> records = new List<BaseDataItem>();
            var roots=result.Where(m=>m.ParentID==null).ToList();

            for (int i = 0; i < roots.Count;i++)
            {
                var item = roots[i];
                records.Add(item);

                if(i==roots.Count-1)
                {
                    item.Name = "└─" + item.Name;
                    BuildItems(item, records,"　　");
                }
                else
                {
                    item.Name = "├─" + item.Name;
                    BuildItems(item, records, "│　");
                }
                
            }

            return new QueryResult<BaseDataItem>
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
                BaseDataItemService.DeleteByID(rid);
                lvQuery.LoadData();
            }
        }

        private void BuildItems(BaseDataItem item,List<BaseDataItem> records,string prefix)
        {
            if (item.Items == null)
                return;
            var items = item.Items.Where(m => m.Status == 1).ToArray();
            for (int i = 0; i < items.Length;i++)
            {
                var subItem = items[i];
                string subPrefix = prefix;
                if(i==items.Length-1)
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