using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

namespace iEAS.Web.UI
{
    public class ObjectDataSource : System.Web.UI.WebControls.ObjectDataSource
    {
        private IPageableDataSource _PageableDataSource = null;

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
            _PageableDataSource = OnQuery(startRowIndex, maxRows);
            return _PageableDataSource;
        }

        public int GetRecordCount()
        {
            return _PageableDataSource.RecordCount;
        }

        protected IPageableDataSource OnQuery(int startRowIndex, int maxRows)
        {
            if(Query!=null)
            {
               return Query(this, new ObjectDataSourceEventArgs{
                    startRowIndex= startRowIndex,
                    maxRows=maxRows
                });
            }
            return null;
        }
    }

    public delegate IPageableDataSource PagedQueryEventHandler(object sender, ObjectDataSourceEventArgs args);

    public class ObjectDataSourceEventArgs:EventArgs
    {
        public int startRowIndex { get; set; }

        public int maxRows { get; set; }
    }
}
