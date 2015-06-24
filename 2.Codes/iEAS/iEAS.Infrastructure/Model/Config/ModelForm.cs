using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace iEAS.Model.Config
{
    [Serializable]
    public class ModelForm
    {
        private List<ModelField> _Fields = new List<ModelField>();
        private List<ModelGroup> _Groups = new List<ModelGroup>();
        private List<ModelParam> _Params = new List<ModelParam>();
        private ModelToolbarItemCollection _Commands = new ModelToolbarItemCollection();
        private ModelNavigationCollection _Navigations = new ModelNavigationCollection();

        [XmlAttribute]
        public string Scene { get; set; }
        [XmlAttribute]
        public string Title { get; set; }
        [XmlAttribute]
        public string Code { get; set; }
        [XmlAttribute]
        public string Table { get; set; }
        [XmlAttribute]
        public string Template { get; set; }
        [XmlAttribute]
        public string Desc { get; set; }
        [XmlArray]
        [XmlArrayItem("Field")]
        public List<ModelField> Fields
        {
            get { return _Fields; }
            set { _Fields = value; }
        }
        [XmlArray]
        [XmlArrayItem("Group")]
        public List<ModelGroup> Groups
        {
            get { return _Groups; }
            set { _Groups = value; }
        }
        [XmlArray]
        [XmlArrayItem("Param")]
        public List<ModelParam> Params
        {
            get { return _Params; }
            set { _Params = value; }
        }

        [XmlArray("Navigations")]
        [XmlArrayItem("Navigation")]
        public ModelNavigationCollection Navigations
        {
            get { return _Navigations; }
            set { _Navigations = value; }
        }

        [XmlArray("Commands")]
        [XmlArrayItem("Command")]
        public ModelToolbarItemCollection Commands
        {
            get { return _Commands; }
            set { _Commands = value; }
        }
    }
}
