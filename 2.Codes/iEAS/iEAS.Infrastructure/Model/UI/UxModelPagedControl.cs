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

        protected override void ExecuteIterator(Action<IReadOnlyDictionary<string, object>> handler)
        {
            StringBuilder sbHtml = new StringBuilder();

            var config = ModelConfig.GetDataSource(DataSourceCode);
            config.PageSize = PageSize;
            config.PageIndex = PageIndex;

            DBEngine engine = new DBEngine();
            IReadOnlyList<IReadOnlyDictionary<string, object>> records = engine.GetRecords(config);
            foreach (var dict in records)
            {
                handler(dict);
            }
        }

        protected override void ExecuteCollection(Action<IReadOnlyList<IReadOnlyDictionary<string, object>>> handler)
        {
            var config = ModelConfig.GetDataSource(DataSourceCode);
            config.PageSize = PageSize;
            config.PageIndex = PageIndex;

            DBEngine engine = new DBEngine();
            IReadOnlyList<IReadOnlyDictionary<string, object>> records = engine.GetRecords(config);
            handler(records);
        }
    }
}
