using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iEAS.Infrastructure.Web.Pages.BaseData
{
    public partial class BaseDataTypeList : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            odsQuery.Query += odsQuery_Query;
        }

        PagedResult odsQuery_Query(object sender, iEAS.Web.UI.ObjectDataSourceEventArgs args)
        {
            return new PagedResult<string>
            {
                RecordCount = 1000,
                Items = new List<string>{
                      "1111"+DateTime.Now,
                      "2222222",
                      "1111",
                      "2222222",
                      "1111",
                      "2222222",
                      "1111",
                      "2222222",
                      "1111",
                      "2222222",
                      "3333333"
                  }
            };
        }
    }
}