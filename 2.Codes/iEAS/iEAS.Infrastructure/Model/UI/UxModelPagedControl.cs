using iEAS.Model.Config;
using iEAS.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace iEAS.Model.UI
{
    public class UxModelPagedControl : UxModelControl
    {
        private int? _RecordCount;

        public UxModelPagedControl()
        {
        }

        public int PageIndex
        {
            get { return Request["pageIndex"].ToInt(1); }
        }

        public int RecordCount
        {
            get
            {
                if (_RecordCount == null)
                {
                    var config = ModelConfig.GetDataSource(DataSourceCode);
                    DBEngine engine = new DBEngine();
                    _RecordCount = engine.GetRecordCount(config);
                }
                return _RecordCount.Value;
            }
        }

        protected override string ExecuteIterator(Func<IReadOnlyDictionary<string, object>, string> handler)
        {
            StringBuilder sbHtml = new StringBuilder();

            var config = ModelConfig.GetDataSource(DataSourceCode);
            config.PageSize = PageSize;
            config.PageIndex = PageIndex;

            DBEngine engine = new DBEngine();
            IReadOnlyList<IReadOnlyDictionary<string, object>> records = engine.GetRecords(config);
            foreach (var dict in records)
            {
                sbHtml.Append(handler(dict));
            }
            return sbHtml.ToString();
        }

        protected override string ExecuteCollection(Func<IReadOnlyList<IReadOnlyDictionary<string, object>>, string> handler)
        {
            var config = ModelConfig.GetDataSource(DataSourceCode);
            config.PageSize = PageSize;
            config.PageIndex = PageIndex;

            DBEngine engine = new DBEngine();
            IReadOnlyList<IReadOnlyDictionary<string, object>> records = engine.GetRecords(config);
            return handler(records);
        }
    }
}
