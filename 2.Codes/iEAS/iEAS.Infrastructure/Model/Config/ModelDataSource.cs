using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.Model.Config
{
    public class ModelDataSource:ICloneable<ModelDataSource>
    {
        public string Code { get; set; }
        public string Sql { get; set; }
        public string OrderBy { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public ModelDataSource Clone()
        {
            return new ModelDataSource
            {
                Code = this.Code,
                Sql = this.Sql,
                OrderBy = this.OrderBy,
                PageIndex = this.PageIndex,
                PageSize = this.PageSize
            };
        }

        object ICloneable.Clone()
        {
            return ((ICloneable<ModelDataSource>)this).Clone();
        }
    }
}
