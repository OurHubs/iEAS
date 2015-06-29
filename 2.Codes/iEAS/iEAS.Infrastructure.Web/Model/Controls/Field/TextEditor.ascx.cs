using iEAS.Model.Data;
using iEAS.Model.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iEAS.Infrastructure.Web.Model.Controls.Field
{
    public partial class TextEditor : ModelFieldControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public override void InitControl(iEAS.Model.Data.Record record)
        {
            if(!Page.ClientScript.IsClientScriptIncludeRegistered("fckeditor"))
            {
                Page.ClientScript.RegisterClientScriptInclude("fckeditor",ResolveUrl("~/Assets/ckeditor/ckeditor.js"));
            }


            if (record != null)
            {
                DataItem item = record.Items[Field.Code];
                if (item != null)
                {
                    txtValue.Text = item.Value.ToStr();
                }
            }
        }

        public override Dictionary<string, object> GetValues()
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            string val = txtValue.Text.Trim();
            if (!String.IsNullOrEmpty(val) || !Field.IgnoreNullOrEmpty)
            {
                result.Add(Field.Code, val);
            }
            return result;
        }
    }
}