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
                    string modelCode = HttpHelper.ValueRequest(ConfigKey);
                    _Form = Config.Forms.GetForm(modelCode);
                    if(_Form==null)
                    {
                        _Form = Config.Forms.GetForm(modelCode.Split('.')[0]);
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
                    string modelCode = HttpHelper.ValueRequest(ConfigKey);
                    _List = Config.Lists.GetList(modelCode);

                    if (_List == null)
                    {
                        _List = Config.Lists.GetList(modelCode.Split('.')[0]);
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
