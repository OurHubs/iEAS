using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace iEAS.Model.Config
{
    [Serializable]
    public class ModelList
    {
        [XmlAttribute]
        public string Title { get; set; }
        [XmlAttribute]
        public string Code { get; set; }
        [XmlArray]
        [XmlArrayItem("Column")]
        public ModelColumnCollection Columns { get; set; }

    }
}
