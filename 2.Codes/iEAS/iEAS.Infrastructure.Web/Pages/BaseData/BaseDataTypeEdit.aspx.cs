﻿using iEAS.BaseData;
using iEAS.Infrastructure.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iEAS.Infrastructure.Web.Pages.BaseData
{
    public partial class BaseDataTypeEdit : EditForm
    {
        public IBaseDataTypeService BaseDataTypeService { get; set; }

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
                if (IsExistDataTypeCode(txtCode.Text.Trim()))
                {
                    ScriptHelper.Alert("该编号已经存在！");
                    return;
                }
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

        private bool IsExistDataTypeCode(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                return false;
            }
            IList<BaseDataType> listUser = BaseDataTypeService.Query(m => m.Code == code);
            return (listUser != null && listUser.Count > 1);
        }
    }
}