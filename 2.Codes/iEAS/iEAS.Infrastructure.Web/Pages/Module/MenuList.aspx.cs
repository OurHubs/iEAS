using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iEAS.Module;


namespace iEAS.Infrastructure.Web.Pages.Module
{
    public partial class MenuList : System.Web.UI.Page
    {
        public IMenuService MenuService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected IPageableDataSource odsQuery_Query(object sender, iEAS.Web.UI.ObjectDataSourceEventArgs args)
        {
            return MenuService.QueryRecord(m => m.Status == 1 
                                           && m.PortalID == PortalID.Value,
                                                        o => o.Asc(m => m.ID),
                                                        args.startRowIndex,
                                                        args.maxRows);
        }

        protected void lvQuery_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                int rid = e.CommandArgument.ToString().ToInt();
                MenuService.DeleteByID(rid);
                lvQuery.LoadData();
            }
        }

        //入口
        public int? PortalID
        {
            get
            {
                return Request["pid"].ToInt(0);
            }
        }
    }
}