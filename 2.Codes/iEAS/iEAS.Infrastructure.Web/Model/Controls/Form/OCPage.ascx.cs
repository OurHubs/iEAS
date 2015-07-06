using iEAS.Model.Config;
using iEAS.Model.Data;
using iEAS.Model.UI;
using iEAS.Module;
using iEAS.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iEAS.Infrastructure.Web.Model.Controls.Form
{
    public partial class OCPage : System.Web.UI.UserControl
    {
        private Channel _Channel;

        protected override void OnInit(EventArgs e)
        {
            IntitModel();
            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public Channel Channel
        {
            get
            {
                if(_Channel==null)
                {
                    IChannelService channelService=ObjectContainer.GetService<IChannelService>();
                    _Channel=channelService.GetByID(HttpHelper.RequestValue("cid").ToInt());
                }
                return _Channel;
            }
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
                if (_Record == null)
                {
                    _Record = GetRecord();
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
            Record orecord = GetRecord();
            Record record=new Record();
            if (orecord!= null)
            {
                record.RecordID = orecord.RecordID;
                record.Status = RecordStatus.Modified;
            }
            else
            {
                record.RecordID = Guid.NewGuid();
                record.Status = RecordStatus.Created;
            }
            record.Table = ModelContext.Current.Form.Table;

            foreach (RepeaterItem item in rptForm.Items)
            {
                ModelFieldContainer ctField = item.FindControl("ctField") as ModelFieldContainer;
                record.Items.AddValues(ctField.GetValues());
            }
            DBEngine engine = new DBEngine();
            engine.Save(record);
            ScriptHelper.Alert("操作成功！");
        }

        protected void rptForm_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            ModelFieldContainer ctField = e.Item.FindControl("ctField") as ModelFieldContainer;
            ctField.FieldCode = (e.Item.DataItem as ModelField).Code;
            ctField.BindField(Record);
        }

        private Record GetRecord()
        {
            int cid = Request["cid"].ToInt();
            if (cid != 0)
            {
                return new DBEngine().GetRecord(ModelContext.Current.Form, new Dictionary<string, object> { { "ChannelID", cid } });
            }
            return null;
        }
    }
}