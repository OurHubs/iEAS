using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace iEAS.Model.Config
{
    public class ModelRegistry
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string Code { get; set; }
        [XmlAttribute]
        public string Desc { get; set; }
        [XmlAttribute]
        public string Module { get; set; }
        [XmlAttribute]
        public string Path { get; set; }

        public static void Save()
        {
        }
    }
}
