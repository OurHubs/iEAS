using iEAS.Model.Config;
using iEAS.Model.Data;
using iEAS.Model.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iEAS.Infrastructure.Web.Model.Template.Form
{
    public partial class OneColumn : System.Web.UI.UserControl
    {
        protected override void OnInit(EventArgs e)
        {
            IntitModel();
            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private void IntitModel()
        {
            rptForm.DataSource = ModelContext.Current.Form.Fields;
            rptForm.DataBind();
        }
        private Record _Record;
        protected Record Record
        {
            get
            {
                if(_Record==null)
                {
                    Guid? rid = Request["rid"].ToNGuid();
                    if(rid!=null)
                    { 
                        _Record = new DBEngine().GetRecord(ModelContext.Current.Form,rid.Value);
                    }
                    if (_Record == null)
                    {
                        _Record = new Record();
                    }
                }
                return _Record;
            }
        }



        protected void btnSave_Click(object sender, EventArgs e)
        {
            Record record = new Record();
            record.Table = ModelContext.Current.Form.Table;

            Guid? rid = Request["rid"].ToNGuid();
            if (rid != null)
            {
                record.RecordID = rid.Value;
                record.Status = RecordStatus.Modified;
            }
            else
            {
                record.Status = RecordStatus.Created;
            }

            foreach(RepeaterItem item in rptForm.Items)
            {
                ModelFieldContainer ctField=item.FindControl("ctField") as ModelFieldContainer;
                record.Items.AddValues(ctField.GetValues());
            }
            DBEngine engine = new DBEngine();
            engine.Save(record);
            Response.Redirect("ModelQuery.aspx?model=" + ModelContext.Current.List.Code);
        }

        protected void rptForm_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            ModelFieldContainer ctField = e.Item.FindControl("ctField") as ModelFieldContainer;
            ctField.FieldCode = (e.Item.DataItem as ModelField).Code;
            ctField.BindField(Record);
        }
    }
}