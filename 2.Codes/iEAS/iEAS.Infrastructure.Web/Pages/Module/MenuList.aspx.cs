﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iEAS.Infrastructure.Web.Pages.Module
{
    public partial class MenuList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //入口
        public int? PortalTypeID
        {
            get
            {
                return Request["pid"].ToInt(0);
            }
        }
    }
}