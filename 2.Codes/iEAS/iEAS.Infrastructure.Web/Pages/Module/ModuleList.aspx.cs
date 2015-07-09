using iEAS.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iEAS.Infrastructure.Web.Pages.Module
{
    public partial class ModuleList : System.Web.UI.Page
    {
        public IModuleService ModuleService { get; set; }

        protected IPageableDataSource odsQuery_Query(object sender, iEAS.Web.UI.ObjectDataSourceEventArgs args)
        {
            return ModuleService.QueryRecord(m => m.Status == 1,
                                                        o => o.Asc(m => m.ID),
                                                        args.startRowIndex,
                                                        args.maxRows);
        }

        protected void lvQuery_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                Guid rid = e.CommandArgument.ToGuid();
                ModuleService.DeleteByID(rid);
                lvQuery.DataBind();
            }
        }
    }
}