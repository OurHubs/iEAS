using iEAS.Model.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iEAS.Infrastructure.Web.Model.Template.Form
{
    public partial class GridEditor : ModelFormControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public override void InitControl(IEnumerable<iEAS.Model.Data.Record> records)
        {
            base.InitControl(records);
            rptGrid.DataSource = new List<string> { "1" };
            rptGrid.DataBind();
        }
    }
}