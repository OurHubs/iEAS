using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iEAS.Domain
{
    public class PagedResult<TEntity>
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int RecordCount { get; set; }

        public int PageCount { get; set; }

        public List<TEntity> Items { get; set; }
    }
}
