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
    public partial class ModuleEdit :EditForm
    {
        public IModuleService ModuleService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var module = ModuleService.GetByID(RecordID);

            if (module == null)
            {
                module = new ModuleInfo();
                bool existCode = IsExistModuleCode(txtCode.Text.Trim());
                if (existCode)
                {
                    ScriptHelper.Alert("该编码已经存在！");
                    return;
                }
            }

            module.Name = txtName.Text.Trim();
            module.Code = txtCode.Text.Trim();
            module.Desc = txtDesc.Text.Trim();
            module.Status = 1;

            try
            {
                ModuleService.CreateOrUpdate(module);
            }
            catch (Exception ex)
            {
                LogManager.GetLogger().Error("保存模块信息出错！", ex);
                throw ex;
            }
            Response.Redirect("ModuleList.aspx");
        }             

        private void BindData()
        {
            var module = ModuleService.GetByID(RecordID);
            if (module != null)
            {
                txtName.Text = module.Name;
                txtCode.Text = module.Code;
                txtDesc.Text = module.Desc;
            }
        }

        private bool IsExistModuleCode(string code)
        {
            IList<ModuleInfo> listRole = ModuleService.Query(m => m.Code == code);
            return (listRole != null && listRole.Count > 1);
        }
    }
}