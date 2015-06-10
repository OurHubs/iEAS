﻿using iEAS.Model.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iEAS.Infrastructure.Web.Model
{
    public partial class ModelEdit : System.Web.UI.Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.Controls.Clear();
            var ctr = Page.LoadControl("~/Model/Template/Form/" + ModelContext.Current.Form.Template + ".ascx");
            this.Controls.Add(ctr);
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            {
               
            }
        }
    }
}