using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace iEAS.Model.Config
{
    [Serializable]
    public class ModelNavigation
    {
        [XmlAttribute]
        public string Title { get; set; }
        [XmlAttribute]
        public string Type { get; set; }
        [XmlAttribute]
        public string Url { get; set; }
        [XmlAttribute]
        public bool IsCurrent { get; set; }
    }
}
