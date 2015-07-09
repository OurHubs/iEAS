using iEAS.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iEAS.Infrastructure.Web.Pages.Account
{
    public partial class RoleList : System.Web.UI.Page
    {
        public IRoleService RoleService { get; set; }

        protected IPageableDataSource odsQuery_Query(object sender, iEAS.Web.UI.ObjectDataSourceEventArgs args)
        {
            return RoleService.QueryRecord(m => m.Status == 1,
                                                        o => o.Asc(m => m.ID),
                                                        args.startRowIndex,
                                                        args.maxRows);
        }

        protected void lvQuery_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                Guid rid = e.CommandArgument.ToGuid();
                RoleService.DeleteByID(rid);
                lvQuery.DataBind();
            }
        }
    }
}