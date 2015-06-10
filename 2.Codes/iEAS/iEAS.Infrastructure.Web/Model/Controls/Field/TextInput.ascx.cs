using iEAS.Model.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iEAS.Infrastructure.Web.Model.Controls.Field
{
    public partial class TextInput : ModelFieldControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public override void InitControl(iEAS.Model.Data.Record record)
        {
            base.InitControl(record);
        }

        public override Dictionary<string, object> GetValues()
        {
            string val = txtValue.Text.Trim();
            return new Dictionary<string, object>{
                {Field.Code,val}
            };
        }
    }
}