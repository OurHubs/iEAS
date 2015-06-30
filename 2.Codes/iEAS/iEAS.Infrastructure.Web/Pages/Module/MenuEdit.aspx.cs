using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iEAS.Module;
using iEAS.Context;

namespace iEAS.Infrastructure.Web.Pages.Module
{
    public partial class MenuEdit : System.Web.UI.Page
    {
        public IMenuService MenuService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            iEAS.Module.Menu menu = MenuService.GetByID(RecordID, true);
            if (menu != null)
            {
                txtName.Text = menu.Name;
                txtValue.Text = menu.Code;
                txtDesc.Text = menu.Desc;
                txtUrl.Text = menu.Url;
                if (menu.ParentID != null)
                {
                    lblParent.Text = menu.Parent.Name;
                }
            }
            else if (ParentID != null)
            {
                var parent = MenuService.GetByID(ParentID.Value);
                if (parent != null)
                {
                    lblParent.Text = parent.Name;
                }
            }
            if (String.IsNullOrEmpty(lblParent.Text))
            {
                lblParent.Text = "顶级数据项";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            iEAS.Module.Menu menu = MenuService.GetByID(RecordID);

            if (menu == null)
            {
                menu = new iEAS.Module.Menu();
                menu.ParentID = ParentID;
            }
            menu.PortalID = PortalID;
            menu.Name = txtName.Text.Trim();
            menu.Code = txtValue.Text.Trim();
            menu.Desc = txtDesc.Text.Trim();
            menu.Url = txtUrl.Text.Trim();
            menu.Status = 1;

            try
            {
                MenuService.CreateOrUpdate(menu);
                PortalContext.Current.ResetPortal();
            }
            catch (Exception ex)
            {
                LogManager.GetLogger().Error("保存基础数据项出错！", ex);
                throw ex;
            }
            Response.Redirect("MenuList.aspx?portalid=" + PortalID);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuList.aspx?portalid=" + PortalID);
        }

        #region 属性
        public int RecordID
        {
            get { return Request["rid"].ToInt(0); }
        }

        public int PortalID
        {
            get
            {
                int? typeID = Request["portalid"].ToNInt();
                if (typeID == null)
                {
                    throw new BusinessException("portalid不能为空！");
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

        #endregion
    }
}