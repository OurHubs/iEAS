using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iEAS.Module;
using iEAS.Context;
using iEAS.Utility;


namespace iEAS.Infrastructure.Web.Pages.Module
{
    public partial class MenuList : System.Web.UI.Page
    {
        public IMenuService MenuService { get; set; }

        private void BuildItems(iEAS.Module.Menu item, List<iEAS.Module.Menu> records, string prefix)
        {
            if (item.Children.Count == 0)
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void gvList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                Guid rid = e.CommandArgument.ToGuid();
                MenuService.DeleteByID(rid);
                BindData();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuEdit.aspx?portalid=" + PortalID.ToStr());
        }

        protected void btnDeleteAll_Click(object sender, EventArgs e)
        {
            Guid[] ids = HttpHelper.GetRequestIds("ids");
            if (ids.Count() > 0)
            {
                MenuService.Delete(m => ids.Contains(m.ID));
                BindData();
                ScriptHelper.Alert("操作成功！");
            }
            else
            {
                ScriptHelper.Alert("请勾选要删除的行！");
            }
        }

        private void BindData()
        {
            var query = MenuService.Query().Where(m => m.Status == 1);
            string name = txtName.Text.Trim();
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(m => m.Name.Contains(name));
            }

            List<iEAS.Module.Menu> records = new List<iEAS.Module.Menu>();
            var roots = query.Where(m => m.ParentID == null).ToList();

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

        public Guid? PortalID
        {
            get
            {
                return Request["portalid"].ToNGuid();
            }
        }
    }
}