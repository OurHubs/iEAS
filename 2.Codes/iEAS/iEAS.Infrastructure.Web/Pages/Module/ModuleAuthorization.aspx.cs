using iEAS.Account;
using iEAS.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iEAS.Infrastructure.Web.Pages.Module
{
    public partial class ModuleAuthorization : System.Web.UI.Page
    {

        public IPermissionService PermissionService { get; set; }

        public IModuleService ModuleService { get; set; }

        public IFeatureService FeatureService { get; set; }

        private IList<ModuleInfo> _Modules;
        public IList<ModuleInfo> Modules
        {
            get
            {
                if (_Modules == null)
                {
                    _Modules = ModuleService.Query(m=>m.Status==1, o => o.Asc(m => m.ID));
                }
                return _Modules;
            }
        }

        public Guid CurrentModuleID
        {
            get
            {
                if(ViewState["CurrentModuleID"]==null)
                {
                    var module = Modules.FirstOrDefault();
                    if(module==null)
                    {
                        throw new BusinessException("没有可用的模块");
                    }
                    ViewState["CurrentModuleID"]=module.ID;
                }
                return (Guid)ViewState["CurrentModuleID"];
            }
            set
            {
                ViewState["CurrentModuleID"] = value;
            }
        }

        public string OwnerGuid
        {
            get
            {
                string guid = Request["OwnerGuid"];
                if (String.IsNullOrEmpty(guid))
                {
                    throw new BusinessException("OwnerGuid不能为空！");
                }
                return guid;
            }
        }

        public string OwnerType
        {
            get
            {
                string ownerType = Request["OwnerType"];
                if (String.IsNullOrEmpty(ownerType))
                {
                    throw new BusinessException("OwnerType不能为空！");
                }
                return ownerType;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindModules();
            }
        }
        protected void rptModule_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            CurrentModuleID = e.CommandArgument.ToGuid();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            var checkFeatures = hfSelectedFeatures.Value.Trim(',');
            string[] ids = new string[0];
            if (!String.IsNullOrEmpty(checkFeatures))
            {
                ids = checkFeatures.Split(',');
            }

            var featureIds = FeatureService.Query(m => m.ModuleID == CurrentModuleID).Select(m => m.ID.ToString());

            PermissionService.SavePermissions(OwnerType, OwnerGuid, ResourceType.Module, ids, featureIds);
        }
        private void BindModules()
        {
            rptModule.DataSource = Modules;
            rptModule.DataBind();
        }

        public string BuildFeatureData()
        {
            var allFeatures = FeatureService.Query(m => m.ModuleID == CurrentModuleID && m.Status == 1);
            var selectedFeatures = PermissionService.GetPermissions(OwnerType, OwnerGuid,ResourceType.Module);

            StringBuilder sbModuleData = new StringBuilder();
            sbModuleData.Append("[");

            foreach (var item in allFeatures)
            {
                sbModuleData.AppendFormat("{{id:{0},pId:{1},name:'{2}',guid:'{3}',open:true,checked:{4}}},", item.ID, item.ParentID.ToStr("null"), item.Name, item.ID, selectedFeatures.Any(m => m.ResouceID == item.ID.ToString()) ? "true" : "false");
            }
            sbModuleData.Trim(',').Append(']');
            hfSelectedFeatures.Value = String.Join(",", selectedFeatures.Select(m => m.ResouceID).ToArray());
            return sbModuleData.ToString();
        }
    }
}