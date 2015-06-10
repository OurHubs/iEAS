using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace iEAS.Model.Config
{
    public class ModelCondition
    {
        /// <summary>
        /// 标题
        /// </summary>
        [XmlAttribute]
        public string Title { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        [XmlAttribute]
        public string Code { get; set; }
        /// <summary>
        /// 控件
        /// </summary>
        [XmlAttribute]
        public string Control { get; set; }

        /// <summary>
        /// 操作
        /// </summary>
        [XmlAttribute]
        public string Operation { get; set; }
    }
}
