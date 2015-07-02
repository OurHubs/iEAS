using iEAS.Model.Config;
using iEAS.Model.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace iEAS.Model.UI
{
    public delegate string IteratorHandler(Func<IReadOnlyDictionary<string, object>, string> handler);
    public delegate string CollectionHandler(Func<IReadOnlyList<IReadOnlyDictionary<string, object>>,string> handler);
    public delegate string RecordHandler(Func<IReadOnlyDictionary<string, object>,string> handler);

    public class UxModelControl : UserControl
    {
        private IteratorHandler _Iterator;
        private CollectionHandler _Collection;
        private RecordHandler _Record;
        private string _DataSourceCode;
        private int _PageSize = 10;
        private ModelDataSource _ModelDataSource;

        public UxModelControl()
        {
            _Iterator = ExecuteIterator;
            _Collection = ExecuteCollection;
            _Record = ExecuteRecord;
        }

        public virtual string DataSourceCode
        {
            get { return _DataSourceCode; }
            set { _DataSourceCode = value; }
        }

        public int PageSize
        {
            get { return _PageSize; }
            set { _PageSize = value; }
        }
        public IteratorHandler Iterator
        {
            get { return _Iterator; }
        }
        public CollectionHandler Collection
        {
            get { return _Collection; }
        }
        public RecordHandler Record
        {
            get { return _Record; }
        }

        protected virtual string  ExecuteIterator(Func<IReadOnlyDictionary<string, object>, string> handler)
        {
            var config = ModelConfig.GetDataSource(DataSourceCode);
            config.PageSize = PageSize;

            DBEngine engine = new DBEngine();
            StringBuilder sbHtml = new StringBuilder();
            IReadOnlyList<IReadOnlyDictionary<string, object>> records = engine.GetRecords(config);
            foreach (var dict in records)
            {
                sbHtml.Append(handler(dict));
            }
            return sbHtml.ToString();
        }

        protected virtual string ExecuteCollection(Func<IReadOnlyList<IReadOnlyDictionary<string, object>>,string> handler)
        {
            var config = ModelConfig.GetDataSource(DataSourceCode);
            config.PageSize = PageSize;

            DBEngine engine = new DBEngine();
            IReadOnlyList<IReadOnlyDictionary<string, object>> records = engine.GetRecords(config);
            return handler(records);
        }

        protected virtual string ExecuteRecord(Func<IReadOnlyDictionary<string, object>,string> handler)
        {
            var config = ModelConfig.GetDataSource(DataSourceCode);

            DBEngine engine = new DBEngine();
            IReadOnlyDictionary<string, object> record = engine.GetRecord(config);
            return handler(record);
        }
    }
}
