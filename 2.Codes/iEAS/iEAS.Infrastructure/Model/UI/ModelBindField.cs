﻿using iEAS.Model.Config;
using iEAS.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iEAS.Model.UI
{
    public class ModelBindField:TemplateField //DataControlField
    {
        public ModelColumn ModelColumn
        {
            get
            {
                ModelColumn column = ViewState["ModelColumn"] as ModelColumn;
                if(column==null)
                {
                    throw new SystemException("模型字段信息为null");
                }
                return column;
            }
            set 
            {
                ViewState["ModelColumn"] = value;
                this.HeaderText = value.Title;
            }
        }

        public override void InitializeCell(DataControlFieldCell cell, DataControlCellType cellType, DataControlRowState rowState, int rowIndex)
        {
            base.InitializeCell(cell, cellType, rowState,rowIndex);

            cell.DataBinding += (sender, e) =>
            {
                if(cellType==DataControlCellType.DataCell)
                {
                    GridViewRow row = cell.NamingContainer as GridViewRow;
                    DataRow dtRow = row.DataItem as DataRow;
                    Dictionary<string, object> values = new Dictionary<string, object>();
                    foreach(DataColumn column in dtRow.Table.Columns)
                    {
                        values[column.ColumnName] = dtRow[column];
                    }
                    HttpHelper.GetViewState(row)["DataSource"] = values;
                }
            };

            cell.PreRender += (sender, e) =>
            {
                if (cellType == DataControlCellType.DataCell)
                {
                    GridViewRow row = cell.NamingContainer as GridViewRow;

                    Dictionary<string,object> values=row.GetViewState()["DataSource"] as Dictionary<string,object>;
                    if (ModelColumn.Control == "Text")
                    {
                        cell.Text = values[ModelColumn.Code] + "";
                    }
                    else
                    {
                        Control ctr = cell.Page.LoadControl("~/Model/Controls/Column/" + ModelColumn.Control + ".ascx");
                        cell.Controls.Add(ctr);
                    }
                }
            };
        }
    }
}
