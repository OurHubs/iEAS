using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace iEAS.Model.Config
{
    [Serializable]
    public class ModelTableColumn
    {
        private bool _Nullable = true;
        private int _MaxLength = 50;
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string Code { get; set; }
        [XmlAttribute]
        public string Type { get; set; }
        [XmlAttribute]
        public int MaxLength
        {
            get { return _MaxLength; }
            set { _MaxLength = value; }
        }
        [XmlAttribute]
        public int MinLength { get; set; }
        [XmlAttribute]
        public bool Nullable
        {
            get { return _Nullable; }
            set { _Nullable = value; }
        }
        [XmlAttribute]
        public bool PrimaryKey { get; set; }
    }
}
