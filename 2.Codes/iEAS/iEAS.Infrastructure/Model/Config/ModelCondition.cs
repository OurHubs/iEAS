using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace iEAS.Model.Config
{
    public class ModelCondition:ModelField
    {
        /// <summary>
        /// 操作
        /// </summary>
        [XmlAttribute]
        public string Operation { get; set; }
    }
}
