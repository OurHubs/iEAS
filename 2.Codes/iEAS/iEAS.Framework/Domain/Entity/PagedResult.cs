using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iEAS
{
    public class PagedResult
    {
        public int RecordCount { get; set; }

        internal virtual IEnumerable DataSource { get; private set; }
    }

    public class PagedResult<TEntity>:PagedResult
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int PageCount { get; set; }

        public List<TEntity> Items { get; set; }

        internal override IEnumerable DataSource
        {
            get
            {
                return Items;
            }
        }
    }
}
