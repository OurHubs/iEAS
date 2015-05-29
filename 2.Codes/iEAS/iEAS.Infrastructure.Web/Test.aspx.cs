using iEAS.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iEAS.Infrastructure.Web
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGenerateDB_Click(object sender, EventArgs e)
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<FrameworkRepository>());
            Database.SetInitializer(new CreateDatabaseIfNotExists<iEASRepository>());
        }
    }
}