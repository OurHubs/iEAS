using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.Model.Data
{
    public class ModelResult : IPageableDataSource
    {
        private DataTable _DataTable = new DataTable();
        private int _RecordCount=0;

        public ModelResult(int recordCount, DataTable table)
        {
            RecordCount = recordCount;
            _DataTable = table; 
        }

        public int RecordCount
        {
            get { return _RecordCount; }
            set { _RecordCount = value; }
        }

        public IEnumerator GetEnumerator()
        {
            return _DataTable.AsDataView().GetEnumerator();
        }
    }
}
