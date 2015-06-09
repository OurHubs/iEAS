using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace iEAS.Model.Config
{
    [Serializable]
    public class ModelField
    {
        private ModelParamCollection _Params = new ModelParamCollection();

        [XmlAttribute]
        public string Title { get; set; }

        [XmlAttribute]
        public string Code { get; set; }

        [XmlAttribute]
        public string Control { get; set; }
        [XmlArray]
        [XmlArrayItem("Param")]
        public ModelParamCollection Params
        {
            get { return _Params; }
            set { _Params = value; }
        }
    }
}
