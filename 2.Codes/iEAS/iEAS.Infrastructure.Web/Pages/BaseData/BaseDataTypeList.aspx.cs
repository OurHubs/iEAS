using iEAS.BaseData;
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
        public IBaseDataTypeService BaseDataTypeService { get; set; }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }

        protected PagedResult odsQuery_Query(object sender, iEAS.Web.UI.ObjectDataSourceEventArgs args)
        {
            return BaseDataTypeService.PagedQuery(m =>m.Status==1,
                                                        o=>o.Asc(m=>m.ID),
                                                        args.startRowIndex,
                                                        args.maxRows);
        }
    }
}