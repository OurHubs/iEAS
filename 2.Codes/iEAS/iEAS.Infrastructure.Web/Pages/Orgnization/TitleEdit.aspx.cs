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
    public partial class TitleEdit : EditForm
    {
        public ITitleService TitleService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var title = TitleService.GetByID(RecordID);

            if (title == null)
            {
                title = new Title();
            }

            title.Name = txtName.Text.Trim();
            title.Code = txtCode.Text.Trim();
            title.Desc = txtDesc.Text.Trim();
            title.Level = txtLeval.Text.Trim();
            title.Status = 1;

            try
            {
                TitleService.CreateOrUpdate(title);
            }
            catch (Exception ex)
            {
                LogManager.GetLogger().Error("保存出错！", ex);
                throw ex;
            }
            Response.Redirect("TitleList.aspx");
        }

        private void BindData()
        {
            var title = TitleService.GetByID(RecordID);
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