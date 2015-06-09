using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace iEAS.Model.Config
{
    [Serializable]
    public class ModelGroup
    {
        private ModelFieldCollection _Fields = new ModelFieldCollection();
        private ModelSubFormCollection _SubForms = new ModelSubFormCollection();
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string Code { get; set; }

        [XmlArray]
        [XmlArrayItem("Field")]
        public ModelFieldCollection Fields
        {
            get { return _Fields; }
            set { _Fields = value; }
        }
        [XmlArray]
        [XmlArrayItem("Form")]
        public ModelSubFormCollection Forms
        {
            get { return _SubForms; }
            set { _SubForms = value; }
        }
    }
}
