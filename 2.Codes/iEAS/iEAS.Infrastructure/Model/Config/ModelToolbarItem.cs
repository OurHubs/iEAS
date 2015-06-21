using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace iEAS.Model.Config
{
    public class ModelToolbarItem
    {
        [XmlAttribute]
        public string Title { get; set; }

        [XmlAttribute]
        public string Command { get; set; }

        [XmlAttribute]
        public string Style { get; set; }
    }
}
