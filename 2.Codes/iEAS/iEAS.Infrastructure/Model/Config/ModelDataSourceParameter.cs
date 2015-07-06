using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace iEAS.Model.Config
{
    [Serializable]
    public class ModelDataSourceParameter
    {
        private bool _Queryable = true;
        /// <summary>
        /// 数据编码
        /// </summary>
        [XmlAttribute]
        public string Name { get; set; }
        /// <summary>
        /// 数据源
        /// </summary>
        [XmlAttribute]
        public string Source { get; set; }
        /// <summary>
        /// 数据值
        /// </summary>
        [XmlAttribute]
        public string Value { get; set; }
        /// <summary>
        /// 查询条件
        /// </summary>
        [XmlAttribute]
        public string Operation { get; set; }
        /// <summary>
        /// 是否可查询
        /// </summary>
        [XmlAttribute]
        public bool Queryable
        {
            get { return _Queryable; }
            set { _Queryable = value; }
        }
    }
}
