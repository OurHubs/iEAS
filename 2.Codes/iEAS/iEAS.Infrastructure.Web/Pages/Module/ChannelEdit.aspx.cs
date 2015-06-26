using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iEAS.Module;

namespace iEAS.Infrastructure.Web.Pages.Module
{
    public partial class ChannelEdit : System.Web.UI.Page
    {
        public IChannelService ChannelService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            Channel model = ChannelService.GetByID(RecordID, true);
            if (model!=null)
            {
                txtCode.Text = model.Code;
                txtName.Text = model.Name;
                txtDesc.Text = model.Desc;
               
                txtTemplate.Text = model.Template;
                ddlChannelType.SelectedValue = model.ChannelType;
            }
            lblParent.Text = "顶级栏目";
            if (ParentID.HasValue)
            {
                Channel parentModel = ChannelService.GetByID(ParentID.Value, true);
                if (parentModel!=null)
                {
                    lblParent.Text = parentModel.Name;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Channel model = ChannelService.GetByID(RecordID);

            if (model == null)
            {
                model = new Channel();
                model.ParentID = ParentID;
            }         
            model.Status = 1;
            model.Name = txtName.Text.Trim();
            model.Code = txtCode.Text.Trim();
            model.Desc = txtDesc.Text.Trim();
           
            model.Template = txtTemplate.Text.Trim();
            ChannelService.CreateOrUpdate(model);

            Response.Redirect("ChannelList.aspx");
        }


        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChannelList.aspx");
        }

        #region 属性区域
        public int RecordID
        {
            get { return Request["rid"].ToInt(0); }
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