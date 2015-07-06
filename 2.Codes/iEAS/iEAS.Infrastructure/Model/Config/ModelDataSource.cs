using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace iEAS.Model.Config
{
    [Serializable]
    public class ModelDataSource:ICloneable<ModelDataSource>
    {
        private ModelDataSourceParameterCollection _Params = new ModelDataSourceParameterCollection();

        [XmlAttribute]
        public string Code { get; set; }
        [XmlElement]
        public string Sql { get; set; }
        [XmlElement]
        public string OrderBy { get; set; }
        [XmlElement]
        public int PageSize { get; set; }
        [XmlElement]
        public int PageIndex { get; set; }

        [XmlArray]
        [XmlArrayItem("Param")]
        public ModelDataSourceParameterCollection Params
        {
            get { return _Params; }
            set { _Params = value; }
        }
        public ModelDataSource Clone()
        {
            var mds=new ModelDataSource
            {
                Code = this.Code,
                Sql = this.Sql,
                OrderBy = this.OrderBy,
                PageIndex = this.PageIndex,
                PageSize = this.PageSize
            };
            foreach(var param in Params)
            {
                mds.Params.Add(new ModelDataSourceParameter
                {
                     Name=param.Name,
                     Operation=param.Operation,
                     Queryable=param.Queryable,
                     Source=param.Source,
                     Value=param.Value
                });
            }

            return mds;
        }

        object ICloneable.Clone()
        {
            return ((ICloneable<ModelDataSource>)this).Clone();
        }
    }
}
