﻿using iEAS.Orgnization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iEAS.Infrastructure.Web.Pages.Controls
{
    public partial class UxPositionSelect : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public List<KeyValuePair<string,string>> GetPostionIds()
        {
            List<KeyValuePair<string, string>> result = new List<KeyValuePair<string, string>>();

            if (!String.IsNullOrEmpty(hfId.Value))
            {
                string[] kvpId=hfId.Value.Split(',');
                foreach(var kvp in kvpId)
                {
                    string[] ss=kvp.Split('_');
                    result.Add(new KeyValuePair<string, string>(ss[0], ss[1]));
                }
            }
            return result;
        }

        public void BindPosition(Guid employeeId)
        {
            IEmployeePositionService service = ObjectContainer.GetService<IEmployeePositionService>();
            var list=service.Query(m => m.EmployeeID == employeeId,null,true);
            StringBuilder sbIds = new StringBuilder();
            StringBuilder sbNames = new StringBuilder();

            foreach(var item in list)
            {
                sbIds.AppendFormat("{0}_{1},", item.DepartmentID, item.PositionID);
                sbNames.AppendFormat("{0}({1}),", item.Position.Name, item.Department.Name);
            }
            sbIds.Trim(',');
            sbNames.Trim(',');
            hfId.Value = sbIds.ToStr();
            hfName.Value = sbNames.ToStr();
        }
    }
}