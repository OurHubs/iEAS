using iEAS.Infrastructure.UI;
using iEAS.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iEAS.Infrastructure.Web.Pages.Module
{
    public partial class FeatureEdit : EditForm
    {
        public IFeatureService FeatureService { get; set; }
        public Guid ModuleID
        {
            get
            {
                Guid? moduleID = Request["moduleID"].ToNGuid();
                if (moduleID == null)
                {
                    throw new BusinessException("ModuleID不能为空！");
                }
                return moduleID.Value;
            }
        }

        public Guid? ParentID
        {
            get
            {
                return Request["parentID"].ToNGuid();
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
            var feature = FeatureService.GetByID(RecordID);

            if (feature == null)
            {
                feature = new Feature();
                feature.ParentID = ParentID;
            }
            feature.ModuleID = ModuleID;
            feature.Name = txtName.Text.Trim();
            feature.Code = txtCode.Text.Trim();
            feature.Desc = txtDesc.Text.Trim();
            feature.Status = 1;

            try
            {
                FeatureService.CreateOrUpdate(feature);
            }
            catch (Exception ex)
            {
                LogManager.GetLogger().Error("保存功能项出错！", ex);
                throw ex;
            }
            Response.Redirect("FeatureList.aspx?moduleID=" + ModuleID);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("FeatureList.aspx?moduleID=" + ModuleID);
        }

        private void BindData()
        {
            var feature = FeatureService.GetByID(RecordID, true);
            if (feature != null)
            {
                txtName.Text = feature.Name;
                txtCode.Text = feature.Code;
                txtDesc.Text = feature.Desc;
                if (feature.ParentID != null)
                {
                    lblParent.Text = feature.Parent.Name;
                }
            }
            else if (ParentID != null)
            {
                var parent = FeatureService.GetByID(ParentID.Value);
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
    }
}