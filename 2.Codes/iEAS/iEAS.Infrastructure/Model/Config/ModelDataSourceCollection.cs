using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.Model.Config
{
    public class ModelDataSourceCollection:Collection<ModelDataSource>
    {
        public ModelDataSource this[string code]
        {
            get { return this.FirstOrDefault(m => m.Code == code); }
        }

        public ModelDataSource GetClone(string code)
        {
            return this[code].Clone();
        }
    }
}
