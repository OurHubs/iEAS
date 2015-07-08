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
        private int? _PageIndex;

        public UxModelPagedControl()
        {
        }

        public int PageIndex
        {
            get
            {
                if(_PageIndex==null || _PageIndex.Value<1)
                {
                    _PageIndex = Page.RouteData.Values["PageIndex"].ToStr().ToInt(1);
                }
                return _PageIndex.Value;
            }
            set { _PageIndex = value; }
        }

        public int RecordCount
        {
            get
            {
                if (_RecordCount == null)
                {
                    var config = ModelConfig.GetDataSource(DataSourceCode);

                    DBEngine engine = new DBEngine();
                    var values = BuildValues(config);
                    _RecordCount = engine.GetRecordCount(config, BuildValues(config));
                }
                return _RecordCount.Value;
            }
            private set { _RecordCount = value; }
        }

        protected override void ExecuteIterator(Action<IReadOnlyDictionary<string, object>> handler)
        {
            var config = ModelConfig.GetDataSource(DataSourceCode);

            DBEngine engine = new DBEngine();
            var values = BuildValues(config);
            ModelPagedRecords records = engine.GetRecords(config, BuildValues(config),PageIndex,PageSize);
            this.RecordCount = records.RecordCount;
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
