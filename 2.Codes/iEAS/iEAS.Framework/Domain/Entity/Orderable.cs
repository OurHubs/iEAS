using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace iEAS.Domain
{
    public class Orderable<TEntity>
    {
        private IQueryable<TEntity> _query;
        public Orderable(IQueryable<TEntity> query)
        {
            _query = query;
        }

        public Orderable<TEntity> Asc<TKey>(Expression<Func<TEntity,TKey>> keySelector)
        {
            _query = _query.OrderBy(keySelector);
            return this;
        }



        public Orderable<TEntity> Desc<TKey>(Expression<Func<TEntity, TKey>> keySelector)
        {
            _query = _query.OrderByDescending(keySelector);
            return this;
        }

        public IQueryable<TEntity> Query
        {
            get { return _query; }
        }
    }
}
