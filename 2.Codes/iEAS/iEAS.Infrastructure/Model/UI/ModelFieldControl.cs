using iEAS.Model.Config;
using iEAS.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace iEAS.Model.UI
{
    public class ModelFieldControl:UserControl
    {
        public ModelField Field { get; set; }

        public virtual void InitControl(Record record)
        {
        }

        public virtual Dictionary<string,object> GetValues()
        {
            return new Dictionary<string, object>();
        }
    }
}
