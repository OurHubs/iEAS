using iEAS.Model.Config;
using iEAS.Web.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace iEAS.Model.UI
{
    public class ModelFieldTemplate:UserControl
    {
        public Dictionary<string,object> Data { get; set; }

        public ModelColumn ModelColumn { get; set; }

        public GridView Grid { get; set; }

        public void BindData(Dictionary<string, object> values)
        {
        }
    }
}
