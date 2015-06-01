using iEAS.BaseData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iEAS.Infrastructure.Web.Pages.BaseData
{
    public partial class BaseDataItemList : System.Web.UI.Page
    {
        public IBaseDataItemService BaseDataItemService { get; set; }

        public int TypeID
        {
            get
            {
                int? typeID = Request["typeid"].ToNInt();
                if (typeID == null)
                {
                    throw new BusinessException("类型ID不能为空！");
                }
                return typeID.Value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected IPageableDataSource odsQuery_Query(object sender, iEAS.Web.UI.ObjectDataSourceEventArgs args)
        {
            return BaseDataItemService.QueryRecord(m => m.Status == 1,
                                                        o => o.Asc(m => m.ID),
                                                        args.startRowIndex,
                                                        args.maxRows,true);
        }

        protected void lvQuery_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                int rid = e.CommandArgument.ToString().ToInt();
                BaseDataItemService.DeleteByID(rid);
                lvQuery.LoadData();
            }
        }
    }
}