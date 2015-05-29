using iEAS.BaseData;
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
            Database.SetInitializer(new DropCreateDatabaseAlways<FrameworkRepository>());
            Database.SetInitializer(new DropCreateDatabaseAlways<iEASRepository>());
            using(var rep=new FrameworkRepository())
            {
                rep.Database.Initialize(true);
            }
            using (var rep = new iEASRepository())
            {
                rep.Database.Initialize(true);
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            using (var rep = ObjectContainer.GetOwnedService<iEASRepository>())
            {
                var dataType = new BaseDataType
                {
                    Name = "1111",
                    Code = "1111",
                    Items = new List<BaseDataItem>
                {
                    new BaseDataItem{ Name="aaaa",Value="aaaa"},
                    new BaseDataItem{ Name="aaaa",Value="aaaa"},
                    new BaseDataItem{ Name="aaaa",Value="aaaa"},
                    new BaseDataItem{ Name="aaaa",Value="aaaa"},
                    new BaseDataItem{ Name="aaaa",Value="aaaa"},
                    new BaseDataItem{ Name="aaaa",Value="aaaa"},
                }
                };
                rep.Create(dataType);
            }
        }
    }
}