using iEAS.Model.Data;
using iEAS.Model.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iEAS.Infrastructure.Web.Model.Controls.Form
{
    public partial class UxForm : System.Web.UI.UserControl
    {
        private Record _Record;
        protected override void OnInit(EventArgs e)
        {
            plForm.Controls.Clear();
            Control ctr = this.LoadControl("~/Config/Model/"+ModelContext.Current.Form.Code+".ascx");
            plForm.Controls.Add(ctr);
            BindData();
            base.OnInit(e);
        }


        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected Record Record
        {
            get
            {
                if (_Record == null)
                {
                    Guid? rid = Request["rid"].ToNGuid();
                    if (rid != null)
                    {
                        _Record = new DBEngine().GetRecord(ModelContext.Current.Form, rid.Value);
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
            DBEngine engine = new DBEngine();

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

            foreach (var ctField in ModelFieldRegistry.Current.Fields)
            {
                record.Items.AddValues(ctField.GetValues());
            }
            
            engine.Save(record);
        }

        private void BindData()
        {
            foreach(var container in ModelFieldRegistry.Current.Fields)
            {
                container.BindField(Record);
            }
        }
    }
}