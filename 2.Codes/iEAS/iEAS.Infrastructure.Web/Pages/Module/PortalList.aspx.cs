using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iEAS.Module;


namespace iEAS.Infrastructure.Web.Pages.Module
{
    public partial class PortalList : System.Web.UI.Page
    {
        public IPortalService PortalService { get; set; }

        protected IPageableDataSource odsQuery_Query(object sender, iEAS.Web.UI.ObjectDataSourceEventArgs args)
        {
            return PortalService.QueryRecord(m => m.Status == 1,
                                                        o => o.Asc(m => m.ID),
                                                        args.startRowIndex,
                                                        args.maxRows);
        }

        protected void lvQuery_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                Guid rid = e.CommandArgument.ToGuid();
                PortalService.DeleteByID(rid);
                lvQuery.DataBind();
            }
        }
    }
}