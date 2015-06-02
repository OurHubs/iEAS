using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iEAS.Module;

namespace iEAS.Infrastructure.Web.Pages.Module
{
    public partial class PortalEdit : System.Web.UI.Page
    {
        public IPortalService PortalService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }
        public int RecordID
        {
            get { return Request["rid"].ToInt(0); }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            PortalInfo portalInfo = PortalService.GetByID(RecordID);

            if (portalInfo == null)
            {
                portalInfo = new PortalInfo();
            }

            portalInfo.Name = txtName.Text.Trim();
            portalInfo.Code = txtCode.Text.Trim();
            portalInfo.Desc = txtDesc.Text.Trim();
            portalInfo.Status = 1;
            try
            {
                PortalService.CreateOrUpdate(portalInfo);
            }
            catch (Exception ex)
            {
                LogManager.GetLogger().Error("保存基础数据类型出错！", ex);
                throw ex;
            }
            Response.Redirect("PortalList.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("PortalList.aspx");
        }

        private void BindData()
        {
            var baseDataTyp = PortalService.GetByID(RecordID);
            if (baseDataTyp != null)
            {
                txtName.Text = baseDataTyp.Name;
                txtCode.Text = baseDataTyp.Code;
                txtDesc.Text = baseDataTyp.Desc;
            }
        }
    }
}