using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace iEAS.Web.UI
{
    public class ObjectDataSource : System.Web.UI.WebControls.ObjectDataSource
    {
        private int _RecordCount = 0;

        public ObjectDataSource()
        {
            this.TypeName = this.GetType().FullName;
            this.MaximumRowsParameterName = "maxRows";
            this.StartRowIndexParameterName = "startRowIndex";
            this.SelectCountMethod = "GetRecordCount";
            this.SelectMethod = "SelectRecords";
            this.EnablePaging = true;
            this.ObjectCreating += ObjectDataSource_ObjectCreating;
        }

        void ObjectDataSource_ObjectCreating(object sender, System.Web.UI.WebControls.ObjectDataSourceEventArgs e)
        {
            e.ObjectInstance = this;
        }

        public event PagedQueryEventHandler Query;

        public IEnumerable SelectRecords(int startRowIndex, int maxRows)
        {
            var result=OnQuery(startRowIndex, maxRows);
            _RecordCount = result.RecordCount;
            return result.DataSource;
        }

        public int GetRecordCount()
        {
            return _RecordCount;
        }

        protected PagedResult OnQuery(int startRowIndex, int maxRows)
        {
            if(Query!=null)
            {
               return Query(this, new ObjectDataSourceEventArgs{
                    startRowIndex= startRowIndex,
                    maxRows=maxRows
                });
            }
            return new PagedResult();
        }
    }

    public delegate PagedResult PagedQueryEventHandler(object sender,ObjectDataSourceEventArgs args);

    public class ObjectDataSourceEventArgs:EventArgs
    {
        public int startRowIndex { get; set; }

        public int maxRows { get; set; }
    }
}
