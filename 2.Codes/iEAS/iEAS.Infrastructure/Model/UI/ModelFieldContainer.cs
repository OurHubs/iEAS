using iEAS.Model.Config;
using iEAS.Model.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace iEAS.Model.UI
{
    public class ModelFieldContainer:PlaceHolder
    {
        private ModelField _Field;

        [Bindable(true)]
        public string FieldCode
        {
            get
            {
                string fieldCode = ViewState["FieldCode"] as String;
                if (String.IsNullOrEmpty(fieldCode))
                {
                    throw new SystemException("模型字段编码不能为空！");
                }
                return fieldCode;
            }
            set
            {
                ViewState["FieldCode"] = value;
            }
        }

        public ModelFieldContainer()
        {
            //this.DataBinding += ModelFieldContainer_DataBinding;
        }

        void ModelFieldContainer_DataBinding(object sender, EventArgs e)
        {
            var rptItem = this.NamingContainer as RepeaterItem;
            BindField(null);
        }

        
        public ModelField Field
        {
            get
            {
                if(_Field==null)
                {
                    _Field = Form.Fields.FirstOrDefault(m => m.Code == FieldCode);
                    if(_Field==null)
                    {
                        _Field = Form.Groups.SelectMany(m => m.Fields).FirstOrDefault(m => m.Code == FieldCode);
                    }
                    if(_Field==null)
                    {
                        throw new SystemException("模型字段配置不存在！");
                    }
                    return _Field;
                }
                return _Field;
            }
        }

        public ModelConfig Config
        {
            get
            {
                return ModelContext.Current.Config;  
            }
        }

        public ModelForm Form
        {
            get
            {
                return ModelContext.Current.Form;
            }
        }

        public void BindField(Record record)
        {
            if (Field.Control == "GridEditor")
            {
                ModelFormControl ctr = Page.LoadControl("~/Model/Template/Form/" + Field.Control + ".ascx") as ModelFormControl;
                if (ctr == null)
                {
                    throw new SystemException("模型控件" + Field.Control + "不存在！");
                }
                ctr.InitControl(null);
                this.Controls.Clear();
                this.Controls.Add(ctr);
            }
            else
            {
                ModelFieldControl ctr = Page.LoadControl("~/Model/Controls/Field/" + Field.Control + ".ascx") as ModelFieldControl;
                if (ctr == null)
                {
                    throw new SystemException("模型控件" + Field.Control + "不存在！");
                }
                ctr.Field = Field;
                ctr.InitControl(null);
                this.Controls.Clear();
                this.Controls.Add(ctr);
            }
        }

        public Dictionary<string,object> GetValues()
        {
            foreach(var ctr in this.Controls)
            {
                if (ctr is ModelFieldControl)
                {
                    ModelFieldControl fieldCtr = ctr as ModelFieldControl;
                    return fieldCtr.GetValues();
                }
            }
            return new Dictionary<string, object>();
        }
    }
}
