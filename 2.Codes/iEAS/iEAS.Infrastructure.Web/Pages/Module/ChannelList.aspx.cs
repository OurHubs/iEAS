using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iEAS.Module;

namespace iEAS.Infrastructure.Web.Pages.Module
{
    public partial class ChannelList : System.Web.UI.Page
    {
        public IChannelService ChannelService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindData();
            }
        }

       

        protected void gvList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                Guid rid = e.CommandArgument.ToGuid();
                ChannelService.DeleteByID(rid);
                //删除子项

                BindData();
            }
        }
        private void BindData()
        {
            var result = ChannelService.Query(m => m.Status == 1, null, true);

            List<iEAS.Module.Channel> records = new List<iEAS.Module.Channel>();
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

        private void BuildItems(iEAS.Module.Channel item, List<iEAS.Module.Channel> records, string prefix)
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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChannelEdit.aspx");
        }
    }
}