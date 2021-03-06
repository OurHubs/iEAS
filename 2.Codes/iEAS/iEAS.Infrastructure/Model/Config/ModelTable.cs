﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace iEAS.Model.Config
{
    [Serializable]
    public class ModelTable
    {
        private ModelTableColumnCollection _Columns = new ModelTableColumnCollection();

        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string Code { get; set; }

        [XmlArray("Columns")]
        [XmlArrayItem("Column")]
        public ModelTableColumnCollection Columns
        {
            get { return _Columns; }
            set { _Columns = value; }
        }
    }
}
