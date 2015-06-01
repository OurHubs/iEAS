using iEAS.BaseData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iEAS.Infrastructure.Web.Pages.BaseData
{
    public partial class BaseDataItemEdit : System.Web.UI.Page
    {
        public IBaseDataItemService BaseDataItemService { get; set; }

        public int RecordID
        {
            get { return Request["rid"].ToInt(0); }
        }
        public int TypeID
        {
            get
            {
                int? typeID = Request["typeid"].ToNInt();
                if (typeID == null)
                {
                    throw new BusinessException("TypeID不能为空！");
                }
                return typeID.Value;
            }
        }

        public int? ParentID
        {
            get
            {
                return Request["parentID"].ToNInt();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var baseDataItem = BaseDataItemService.GetByID(RecordID);

            if (baseDataItem == null)
            {
                baseDataItem = new BaseDataItem();
                baseDataItem.ParentID = ParentID;
            }
            baseDataItem.TypeID = TypeID;
            baseDataItem.Name = txtName.Text.Trim();
            baseDataItem.Value = txtValue.Text.Trim();
            baseDataItem.Desc = txtDesc.Text.Trim();
            baseDataItem.Status = 1;

            try
            {
                BaseDataItemService.CreateOrUpdate(baseDataItem);
            }
            catch (Exception ex)
            {
                LogManager.GetLogger().Error("保存基础数据项出错！", ex);
                throw ex;
            }
            Response.Redirect("BaseDataItemList.aspx?typeId="+TypeID);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("BaseDataItemList.aspx?typeId=" + TypeID);
        }

        private void BindData()
        {
            var baseDataItem = BaseDataItemService.GetByID(RecordID,true);
            if (baseDataItem != null)
            {
                txtName.Text = baseDataItem.Name;
                txtValue.Text = baseDataItem.Value;
                txtDesc.Text = baseDataItem.Desc;
                if (baseDataItem.ParentID != null)
                {
                    lblParent.Text = baseDataItem.Parent.Name;
                }
            }
            else if(ParentID!=null)
            {
                var parent= BaseDataItemService.GetByID(ParentID.Value);
                if(parent!=null)
                {
                    lblParent.Text = parent.Name;
                }
            }
            if(String.IsNullOrEmpty(lblParent.Text))
            {
                lblParent.Text = "顶级数据项";
            }
        }
    }
}