using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace iEAS.Model.Config
{
    [Serializable]
    public class ModelSubForm
    {
        private ModelFieldCollection _Fields = new ModelFieldCollection();
        private ModelGroupCollection _Groups = new ModelGroupCollection();
        private ModelParamCollection _Params = new ModelParamCollection();

        [XmlAttribute]
        public string Title { get; set; }
        [XmlAttribute]
        public string Code { get; set; }
        [XmlAttribute]
        public string Table { get; set; }
        [XmlArray]
        [XmlArrayItem("Field")]
        public ModelFieldCollection Fields
        {
            get { return _Fields; }
            set { _Fields = value; }
        }
        [XmlArray]
        [XmlArrayItem("Group")]
        public ModelGroupCollection Groups
        {
            get { return _Groups; }
            set { _Groups = value; }
        }
        [XmlArray]
        [XmlArrayItem("Param")]
        public ModelParamCollection Params
        {
            get { return _Params; }
            set { _Params = value; }
        }
    }
}
