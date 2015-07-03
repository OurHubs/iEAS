using iEAS.Model.Config;
using iEAS.Model.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;

namespace iEAS.Model.UI
{
    public delegate void IteratorHandler(Action<IReadOnlyDictionary<string, object>> handler);
    public delegate void CollectionHandler(Action<IReadOnlyList<IReadOnlyDictionary<string, object>>> handler);
    public delegate void RecordHandler(Action<IReadOnlyDictionary<string, object>> handler);

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

        public string Title { get; set; }

        public virtual string DataSourceCode
        {
            get { return _DataSourceCode; }
            set { _DataSourceCode = value; }
        }

        public string RecordID { get; set; }

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

        protected virtual void  ExecuteIterator(Action<IReadOnlyDictionary<string, object>> handler)
        {
            var config = ModelConfig.GetDataSource(DataSourceCode);
            config.PageSize = PageSize;

            DBEngine engine = new DBEngine();
            StringBuilder sbHtml = new StringBuilder();
            IReadOnlyList<IReadOnlyDictionary<string, object>> records = engine.GetRecords(config);
            foreach (var dict in records)
            {
                handler(dict);
            }
            //HttpContext.Current.Response.Write(sbHtml);
        }

        protected virtual void ExecuteCollection(Action<IReadOnlyList<IReadOnlyDictionary<string, object>>> handler)
        {
            var config = ModelConfig.GetDataSource(DataSourceCode);
            config.PageSize = PageSize;

            DBEngine engine = new DBEngine();
            IReadOnlyList<IReadOnlyDictionary<string, object>> records = engine.GetRecords(config);
            handler(records);
        }

        protected virtual void ExecuteRecord(Action<IReadOnlyDictionary<string, object>> handler)
        {
            var config = ModelConfig.GetDataSource(DataSourceCode);
            Dictionary<string, object> values = BuildValues(config);

            DBEngine engine = new DBEngine();
            IReadOnlyDictionary<string, object> record = engine.GetRecord(config,values);
            handler(record);
        }

        private Dictionary<string,object> BuildValues(ModelDataSource dsConfig)
        {
            Dictionary<string,object> values=new Dictionary<string,object>();

            foreach(var item in dsConfig.Params)
            {
                switch (item.Source.ToStr().ToLower())
                {
                    case "recordid":
                        values.Add(item.Name, RecordID);
                        break;
                    default:
                        break;
                }
            }

            return values;
        }
    }
}
