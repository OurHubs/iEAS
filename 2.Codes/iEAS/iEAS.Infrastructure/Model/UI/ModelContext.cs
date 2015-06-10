using iEAS.Model.Config;
using iEAS.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace iEAS.Model.UI
{
    public class ModelContext
    {
        private static readonly string ConfigKey = "model";
        private static readonly string FormKey = "form";
        private static readonly string ListKey = "list";

        private ModelConfig _Config;
        private ModelForm _Form;
        private ModelList _List;

        public static ModelContext Current
        {
            get
            {
                ModelContext ctx=HttpContext.Current.Items[typeof(ModelContext)] as ModelContext;
                if(ctx==null)
                {
                    ctx = new ModelContext();
                    HttpContext.Current.Items[typeof(ModelContext)] = ctx;
                }
                return ctx;
            }
        }

        public ModelConfig Config
        {
            get
            {
                if(_Config==null)
                {
                    string cfgCode=HttpHelper.ValueRequest(ConfigKey);
                    if(String.IsNullOrWhiteSpace(cfgCode))
                        throw new SystemException("model值不存在！");

                    _Config=ModelConfig.GetConfig(cfgCode);
                    if(_Config==null)
                    {
                        throw new SystemException("Model=" + cfgCode + "对应的模型不存在！");
                    }
                    return _Config;
                }
                return _Config;
            }
        }

        public ModelForm Form
        {
            get
            {
                if(_Form==null)
                { 
                    string formCode = HttpHelper.ValueRequest(FormKey);
                    if (String.IsNullOrWhiteSpace(formCode))
                    {
                        _Form = Config.Forms.FirstOrDefault();
                    }
                    else
                    {
                        _Form = Config.Forms.GetForm(formCode);
                    }
                    if(_Form==null)
                    {
                        throw new SystemException("没有可用的模型表单配置");
                    }
                }
                return _Form;
            }
        }

        public ModelList List
        {
            get
            {
                if (_List == null)
                {
                    string listCode = HttpHelper.ValueRequest(ListKey);
                    if (String.IsNullOrWhiteSpace(listCode))
                    {
                        _List = Config.Lists.FirstOrDefault();
                    }
                    else
                    {
                        _List = Config.Lists.GetList(listCode);
                    }
                    if (_List == null)
                    {
                        throw new SystemException("没有可用的模型列表配置");
                    }
                }
                return _List;
            }
        }
    }
}
