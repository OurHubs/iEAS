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

        protected IPageableDataSource odsQuery_Query(object sender, iEAS.Web.UI.ObjectDataSourceEventArgs args)
        {
            return BaseDataTypeService.QueryRecord(m =>m.Status==1,
                                                        o=>o.Asc(m=>m.ID),
                                                        args.startRowIndex,
                                                        args.maxRows);
        }

        protected void lvQuery_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if(e.CommandName=="Del")
            {
                int rid =e.CommandArgument.ToString().ToInt();
                BaseDataTypeService.DeleteByID(rid);
                lvQuery.LoadData();
            }
        }
    }
}