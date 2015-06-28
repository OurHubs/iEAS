using iEAS.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace iEAS.Model.Config
{
    [Serializable]
    [XmlRoot("ModelRegistryCollection")]
    public class ModelRegistryCollection:Collection<ModelRegistry>
    {
        public void Save()
        {
            string path=Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Config/Model/ModelRegistry.config");
            XmlHelper.Serialize(this, path);
        }

        public static ModelRegistryCollection GetRegistries()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config/Model/ModelRegistry.config");
            return XmlHelper.Deserialize<ModelRegistryCollection>(path);
        }
    }
}
