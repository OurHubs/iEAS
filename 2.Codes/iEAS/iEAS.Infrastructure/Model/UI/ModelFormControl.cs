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
    public class ModelFormControl:UserControl
    {
        public ModelForm Form { get; set; }

        public virtual void InitControl(IEnumerable<Record> records)
        {
        }

        public virtual Dictionary<string, object> GetValues()
        {
            return new Dictionary<string, object>();
        }
    }
}
