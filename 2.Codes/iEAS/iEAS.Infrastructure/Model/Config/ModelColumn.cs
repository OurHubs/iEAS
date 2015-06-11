using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace iEAS.Model.Config
{
    [Serializable]
    public class ModelColumn
    {
        private string _Control = "Text";
        [XmlAttribute]
        public string Title { get; set; }
        [XmlAttribute]
        public string Code { get; set; }
        [XmlAttribute]
        public string Control
        {
            get { return _Control; }
            set { _Control = value; }
        }
    }
}
