using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.Model.Config
{
    [Serializable]
    public class ModelParamCollection:Collection<ModelParam>
    {
        public bool ContainsKey(string key)
        {
            return this.Any(m => m.Name == key);
        }

        public string this[string key]
        {
            get
            {
                if (!this.ContainsKey(key))
                    throw new SystemException("不存在指定的参数:" + key);
                return this.First(m => m.Name == key).Value;
            }
        }
    }
}
