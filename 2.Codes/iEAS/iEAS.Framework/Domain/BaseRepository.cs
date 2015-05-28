using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace iEAS.Domain
{
    public class BaseRepository : DbContext
    {
        /// <summary>
        /// 按指定条件查找到像
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public TEntity Get<TEntity>(Expression<Func<TEntity,bool>> predicate) where TEntity:class
        {
            return this.Set<TEntity>().FirstOrDefault(predicate);
        }

        /// <summary>
        /// 获取集合中的第一个对象
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public TEntity Get<TEntity>() where TEntity:class
        {
            return this.Set<TEntity>().FirstOrDefault();
        }

        public IQueryable<TEntity> Query<TEntity>(Expression<Func<TEntity,bool>> predicate=null,Action<Orderable<TEntity>> orderby=null)
            where TEntity:class
        {
            IQueryable<TEntity> query = this.Set<TEntity>();
            if(predicate!=null)
            {
                query = query.Where(predicate);
            }
            if(orderby!=null)
            {
                Orderable<TEntity> order=new Orderable<TEntity>(query);
                orderby(order);
                query = order.Query;
            }

            return query;
        }

        public IQueryable<TEntity> Query<TEntity>(Expression<Func<TEntity,bool>> predicate,Action<Orderable<TEntity>> orderby,int startRow,int maxRows)
            where TEntity:class
        {
            var query = Query<TEntity>(predicate, orderby);
            query.Skip(startRow).Take(maxRows);
            return query;
        }

        public PagedResult<TEntity> PagedQuery<TEntity>(Expression<Func<TEntity,bool>> predicate,Action<Orderable<TEntity>> orderby,int pageIndex,int pageSize)
            where TEntity:class
        {
            var startRow = (pageIndex - 1) * pageSize;
            var query = Query<TEntity>(predicate, orderby);

            return new PagedResult<TEntity>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                RecordCount=query.Count(),
                Items=query.Skip(startRow).Take(pageSize).ToList()
            };
        }

        public PagedResult<TEntity> PagedQuery<TEntity>(Action<Orderable<TEntity>> orderby, int pageIndex, int pageSize)
            where TEntity : class
        {
            return PagedQuery<TEntity>(null, orderby, pageIndex, pageSize);
        }

        /// <summary>
        /// 添加实体对象
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        public void Create<TEntity>(TEntity entity) where TEntity:class
        {
            this.Set<TEntity>().Add(entity);
            this.SaveChanges();
        }

        public void Update<TEntity>(TEntity entity) where TEntity:class
        {
            this.Entry<TEntity>(entity);
            this.SaveChanges();
        }

        public void Delete<TEntity>(TEntity entity) where TEntity:class
        {
            this.Set<TEntity>().Remove(entity);
            this.SaveChanges();
        }

        public static TResult Transact<TRepository,TResult>(Func<TRepository, TResult> handler, bool layzLoad = false)
            where TRepository:BaseRepository,new()
        {
            if (layzLoad)
            {
                var rep = ObjectContainer.Resolve<TRepository>();
                return handler(rep);
            }
            else
            {
                using (var rep = new TRepository())
                {
                    return handler(rep);
                }
            }
        }

        public static void Transact<TRepository>(Action<TRepository> handler)
            where TRepository:BaseRepository,new()
        {
            using (var rep = new TRepository())
            {
                handler(rep);
            }
        }
    }
}
