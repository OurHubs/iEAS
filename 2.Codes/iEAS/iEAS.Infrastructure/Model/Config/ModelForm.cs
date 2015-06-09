﻿using System;
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

        [XmlAttribute]
        public string Scene { get; set; }
        [XmlAttribute]
        public string Title { get; set; }
        [XmlAttribute]
        public string Code { get; set; }
        [XmlAttribute]
        public string Table { get; set; }
        [XmlAttribute]
        public string Control { get; set; }
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
    }
}
