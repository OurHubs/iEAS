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
    public partial class CheckBox : ModelFieldControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public override void InitControl(iEAS.Model.Data.Record record)
        {
            if (record != null)
            {
                DataItem item = record.Items[Field.Code];
                if (item != null)
                {
                    txtValue.Checked = item.Value.ToStr() == "1";
                }
            }
        }

        public override Dictionary<string, object> GetValues()
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            result.Add(Field.Code, txtValue.Checked?1:0);
            return result;
        }
    }
}