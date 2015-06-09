using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace iEAS.Model.Config
{
    [Serializable]
    public class ModelTable
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string Code { get; set; }
        [XmlAttribute]
        public string Type { get; set; }
    }
}
