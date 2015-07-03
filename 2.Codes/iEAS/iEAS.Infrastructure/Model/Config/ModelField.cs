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
        private bool _Visible = true;
        private string _DataType = "string";
        private string _Title;

        [XmlAttribute]
        public string Title
        {
            get
            {
                return !String.IsNullOrWhiteSpace(_Title) ? _Title : Code;
            }
            set { _Title = value; }
        }

        [XmlAttribute]
        public string Code { get; set; }

        [XmlAttribute]
        public string Control { get; set; }

        [XmlAttribute]
        public string DataType
        {
            get { return _DataType; }
            set { _DataType = value; }
        }

        /// <summary>
        /// 是否必填项
        /// </summary>
        [XmlAttribute]
        public bool IsRequired { get; set; }

        [XmlAttribute]
        public bool Visible
        {
            get { return _Visible; }
            set { _Visible = value; }
        }
        /// <summary>
        /// 忽略空值
        /// </summary>
        [XmlAttribute]
        public bool IgnoreNullOrEmpty { get; set; }

        [XmlArray]
        [XmlArrayItem("Param")]
        public ModelParamCollection Params
        {
            get { return _Params; }
            set { _Params = value; }
        }
    }
}
