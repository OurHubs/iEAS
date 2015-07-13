using iEAS.Infrastructure.UI;
using iEAS.Orgnization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iEAS.Infrastructure.Web.Pages.Orgnization
{
    public partial class PositionEdit : EditForm
    {
        public IPositionService PositionService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var position = PositionService.GetByID(RecordID);

            if (position == null)
            {
                position = new Position();
            }

            position.Name = txtName.Text.Trim();
            position.Code = txtCode.Text.Trim();
            position.Desc = txtDesc.Text.Trim();
            position.Level = txtLeval.Text.Trim();
            position.Status = 1;

            try
            {
                PositionService.CreateOrUpdate(position);
            }
            catch (Exception ex)
            {
                LogManager.GetLogger().Error("保存出错！", ex);
                throw ex;
            }
            Response.Redirect("PositionList.aspx");
        }

        private void BindData()
        {
            var title = PositionService.GetByID(RecordID);
            if (title != null)
            {
                txtName.Text = title.Name;
                txtCode.Text = title.Code;
                txtLeval.Text = title.Level;
                txtDesc.Text = title.Desc;
            }
        }
    }
}