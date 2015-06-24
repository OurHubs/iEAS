using iEAS.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace iEAS.Model.Config
{
    [XmlRoot]
    [Serializable]
    public class ModelConfig
    {
        private ModelFormCollection _Forms = new ModelFormCollection();
        private ModelListCollection _Lists = new ModelListCollection();
        private ModelTableCollection _Tables = new ModelTableCollection();


        public static ModelConfig GetConfig(string code)
        {
            code=code.Split('.')[0];
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Config/Model" ,code + ".xml");
            return XmlHelper.Deserialize<ModelConfig>(filePath);
        }

        public void Save()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config/Model", this.Code + ".xml");
            Helper.EnsureParentDirectoryExist(filePath);
            XmlHelper.Serialize(this,filePath);
        }

        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public string Code { get; set; }

        [XmlArray]
        [XmlArrayItem("Form")]
        public ModelFormCollection Forms
        {
            get { return _Forms; }
            set { _Forms = value; }
        }

        [XmlArray]
        [XmlArrayItem("List")]
        public ModelListCollection Lists
        {
            get { return _Lists; }
            set { _Lists = value; }
        }

        [XmlArray]
        [XmlArrayItem("Table")]
        public ModelTableCollection Tables
        {
            get { return _Tables; }
            set { _Tables = value; }
        }
    }
}
