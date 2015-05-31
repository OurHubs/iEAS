using iEAS.BaseData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iEAS.Infrastructure.Web.Pages.BaseData
{
    public partial class BaseDataTypeEdit : System.Web.UI.Page
    {
        public IBaseDataTypeService BaseDataTypeService { get; set; }

        public int RecordID
        {
            get { return Request["rid"].ToInt(0); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindData();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var baseDataTyp = BaseDataTypeService.GetByID(RecordID);

            if(baseDataTyp==null)
            {
                baseDataTyp = new BaseDataType();
            }

            baseDataTyp.Name = txtName.Text.Trim();
            baseDataTyp.Code = txtCode.Text.Trim();
            baseDataTyp.Desc = txtDesc.Text.Trim();
            baseDataTyp.Status = 1;

            try
            {
                BaseDataTypeService.CreateOrUpdate(baseDataTyp);
            }
            catch(Exception ex)
            {
                LogManager.GetLogger().Error("保存基础数据类型出错！", ex);
                throw ex;
            }
            Response.Redirect("BaseDataTypeList.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("BaseDataTypeList.aspx");
        }

        private void BindData()
        {
            var baseDataTyp=BaseDataTypeService.GetByID(RecordID);
            if(baseDataTyp!=null)
            { 
                txtName.Text = baseDataTyp.Name;
                txtCode.Text = baseDataTyp.Code;
                txtDesc.Text = baseDataTyp.Desc;
            }
        }
    }
}