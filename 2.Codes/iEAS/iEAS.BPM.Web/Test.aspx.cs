using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iEAS.BPM.Web
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGenerateDB_Click(object sender, EventArgs e)
        {
            Database.SetInitializer(new DatabaseInitializer());
            using (var rep = new BPMRepository())
            {
                rep.Database.Initialize(true);
            }
        }
    }

    public class DatabaseInitializer : DropCreateDatabaseAlways<BPMRepository>
    {
        protected override void Seed(BPMRepository context)
        {
            base.Seed(context);
        }
    }
}