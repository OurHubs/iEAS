using iEAS.BaseData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iEAS.Utility;

namespace iEAS.Infrastructure.Web.Pages.BaseData
{
    public partial class BaseDataItemList : System.Web.UI.Page
    {
        public IBaseDataItemService BaseDataItemService { get; set; }
        public IBaseDataTypeService BaseDataTypeService { get; set; }

        public Guid TypeID
        {
            get
            {
                Guid? typeID = Request["typeid"].ToNGuid();
                if (typeID == null)
                {
                    throw new BusinessException("类型ID不能为空！");
                }
                return typeID.Value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
                BindDataType();
            }
        }

        private void BindDataType()
        {
            BaseDataType type = BaseDataTypeService.GetByID(TypeID);
            litDataTypeTitle.Text = type.Name;
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
                BaseDataItemService.DeleteByID(rid);
                BindData();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("BaseDataItemEdit.aspx?typeid=" + TypeID.ToStr());
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("BaseDataTypeList.aspx");
        }

        
        protected void btnDeleteAll_Click(object sender, EventArgs e)
        {
            Guid[] ids = HttpHelper.GetRequestIds("ids");
            if (ids.Count() > 0)
            {
                BaseDataItemService.Delete(m => ids.Contains(m.ID));
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
            var query = BaseDataItemService.Query().Where(m => m.Status == 1);
            string name = txtName.Text.Trim();
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(m => m.Name.Contains(name));
            }
            query = query.Where(m => m.TypeID == TypeID);

            List<BaseDataItem> records = new List<BaseDataItem>();
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

        private void BuildItems(BaseDataItem item, List<BaseDataItem> records, string prefix)
        {
            if (item.Items == null)
                return;
            var items = item.Items.Where(m => m.Status == 1).ToArray();
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