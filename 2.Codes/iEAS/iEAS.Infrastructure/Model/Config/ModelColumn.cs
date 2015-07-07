using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Xml.Serialization;

namespace iEAS.Model.Config
{
    [Serializable]
    public class ModelColumn
    {
        private string _Control = "Text";
        private HorizontalAlign _HorizontalAlign = HorizontalAlign.Left;
        [XmlAttribute]
        public string Title { get; set; }
        [XmlAttribute]
        public string Code { get; set; }
        [XmlAttribute]
        public string Width { get; set; }
        [XmlAttribute]
        public HorizontalAlign HorizontalAlign
        {
            get { return _HorizontalAlign; }
            set { _HorizontalAlign = value; }
        }
        [XmlAttribute]
        public string Control
        {
            get { return _Control; }
            set { _Control = value; }
        }
    }
}
