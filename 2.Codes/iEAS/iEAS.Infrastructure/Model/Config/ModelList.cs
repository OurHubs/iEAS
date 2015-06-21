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
        private string _Template = "PagedQuery";
        private ModelConditionCollection _Conditions = new ModelConditionCollection();
        private ModelColumnCollection _Columns = new ModelColumnCollection();
        private ModelDBCommand _DBCommand = new ModelDBCommand();
        private ModelToolbarItemCollection _TopBar = new ModelToolbarItemCollection();
        private ModelToolbarItemCollection _FooterBar = new ModelToolbarItemCollection();

        [XmlAttribute]
        public string Title { get; set; }
        [XmlAttribute]
        public string Code { get; set; }
        [XmlAttribute]
        public string Template { get; set; }
        [XmlArray]
        [XmlArrayItem("Condition")]
        public ModelConditionCollection Conditions
        {
            get { return _Conditions; }
            set { _Conditions = value; }
        }
        [XmlArray]
        [XmlArrayItem("Column")]
        public ModelColumnCollection Columns
        {
            get { return _Columns; }
            set { _Columns = value; }
        }

        [XmlElement("DBCommand")]
        public ModelDBCommand DBCommand
        {
            get { return _DBCommand; }
            set { _DBCommand = value; }
        }

        [XmlArray("TopBar")]
        [XmlArrayItem("Item")]
        public ModelToolbarItemCollection TopBar
        {
            get { return _TopBar; }
            set { _TopBar = value; }
        }

        [XmlArray("FooterBar")]
        [XmlArrayItem("Item")]
        public ModelToolbarItemCollection FooterBar
        {
            get { return _FooterBar; }
            set { _FooterBar = value; }
        }
    }
}
