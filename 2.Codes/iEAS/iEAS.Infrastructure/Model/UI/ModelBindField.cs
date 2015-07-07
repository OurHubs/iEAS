using iEAS.Model.Config;
using iEAS.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.HtmlControls;
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

            cell.Init += (sender, e) =>
            {
                if (cellType == DataControlCellType.DataCell)
                {
                    if(ModelColumn.Control=="CheckBox")
                    {
                        cell.Controls.Clear();
                        HtmlInputCheckBox chkValue = new HtmlInputCheckBox();
                        chkValue.Attributes.Add("data", ModelColumn.Code + "s");
                        chkValue.ID = ModelColumn.Code;
                        cell.Controls.Add(chkValue);
                    }
                    else if (ModelColumn.Control != "Text")
                    {
                        cell.Controls.Clear();
                        ModelFieldTemplate tpl = cell.Page.LoadControl("~/Model/Controls/Column/" + ModelColumn.Control + ".ascx") as ModelFieldTemplate;
                        tpl.ModelColumn = ModelColumn;
                        cell.Controls.Add(tpl);
                    }
                }
                else if(cellType==DataControlCellType.Header)
                {
                    
                    if (ModelColumn.Control == "CheckBox")
                    {
                        cell.Controls.Clear();
                        HtmlInputCheckBox checkAll = new HtmlInputCheckBox();
                        checkAll.ID = ModelColumn.Code;
                        checkAll.Attributes["onclick"] = "checkAll(this,'"+checkAll.ID+"s')";
                        cell.Controls.Add(checkAll);
                    }
                }
                if (!String.IsNullOrWhiteSpace(ModelColumn.Width))
                {
                    cell.Width = Unit.Parse(ModelColumn.Width);
                }
                cell.HorizontalAlign = ModelColumn.HorizontalAlign;
            };

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

                    if (ModelColumn.Control == "Text")
                    {
                        cell.Text = values[ModelColumn.Code] + "";
                    }
                    else if(ModelColumn.Control =="CheckBox")
                    {
                        HtmlInputCheckBox chkValue=cell.Controls[0] as HtmlInputCheckBox;
                        chkValue.Value = values[ModelColumn.Code].ToStr();
                    }
                    else
                    {
                        foreach(var control in cell.Controls)
                        {
                            ModelFieldTemplate tpl = control as ModelFieldTemplate;
                            if(tpl!=null)
                            {
                                tpl.Data = values;
                                tpl.BindData(values);
                            }
                        }
                    }
                }
            };
        }
    }
}
