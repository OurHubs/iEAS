using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iEAS
{
    public interface IPageableDataSource:IEnumerable
    {
        int RecordCount { get; set; }
    }

    public class QueryResult<TEntity>:List<TEntity>,IPageableDataSource
    {
        public List<TEntity> Items
        {
            get { return this; }
            set { this.AddRange(value); }
        }

        public int RecordCount { get; set; }
    }

    public class PagedResult<TEntity> :List<TEntity>,IPageableDataSource
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int PageCount { get; set; }

        public List<TEntity> Items
        {
            get { return this; }
            set { this.AddRange(value); }
        }

        public int RecordCount { get; set; }
    }
}
