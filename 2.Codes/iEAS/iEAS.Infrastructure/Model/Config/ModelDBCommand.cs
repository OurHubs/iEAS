using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace iEAS.Model.Config
{
    public class ModelDBCommand
    {
        private ModelQuery _Query = new ModelQuery();
        private ModelDelete _Delete = new ModelDelete();

        [XmlElement("Query")]
        public ModelQuery Query
        {
            get { return _Query; }
            set { _Query = value; }
        }

        [XmlElement("Delete")]
        public ModelDelete Delete
        {
            get { return _Delete; }
            set { _Delete = value; }
        }
        [XmlElement("DeleteAll")]
        public ModelDelete DeleteAll
        {
            get { return _Delete; }
            set { _Delete = value; }
        }
    }

    public class ModelQuery
    {
        [XmlElement]
        public string Sql { get; set; }

        [XmlElement]
        public string OrderBy { get; set; }
    }

    public class ModelDelete
    {
        [XmlElement]
        public string Sql { get; set; }
    }
    public class ModelDeleteAll
    {
        [XmlElement]
        public string Sql { get; set; }
    }
}
