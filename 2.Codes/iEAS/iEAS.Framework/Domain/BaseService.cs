using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace iEAS.Domain
{
     public class BaseService<TRepository>
        where TRepository:BaseRepository,new()
     {
         public TResult Transact<TResult>(Func<TRepository, TResult> handler, bool layzLoad = false)
         {
             return BaseRepository.Transact<TRepository, TResult>(handler, layzLoad);
         }

         public void Transact(Action<TRepository> handler)
         {
             BaseRepository.Transact<TRepository>(handler);
         }
     }

    public class BaseService<TEntity,TRepository>
        :BaseService<TRepository>,IBaseService<TEntity,TRepository> 
        where TRepository:BaseRepository,new()
        where TEntity:BaseEntity
    {
        public TEntity GetByID(int id,bool lazyLoad=false)
        {
            return Get(m => m.ID==id, lazyLoad);
        }

        public TEntity GetByGuid(Guid guid,bool lazyLoad=false)
        {
            return Get(m => m.Guid == guid, lazyLoad);
        }

        public TEntity Get(Expression<Func<TEntity,bool>> predicate, bool lazyLoad = false)
        {
            return Transact<TEntity>(rep => rep.Get<TEntity>(predicate), lazyLoad);
        }

        public IList<TEntity> Query(Expression<Func<TEntity,bool>> predicate,Action<Orderable<TEntity>> orderBy=null,bool lazyLoad=false)
        {
            return Transact<IList<TEntity>>(rep =>
                {
                    return rep.Query<TEntity>(predicate, orderBy).ToList();
                }
                ,lazyLoad);
        }

        public IList<TEntity> Query(Action<Orderable<TEntity>> orderBy = null, bool lazyLoad = false)
        {
            return Query(null, orderBy, lazyLoad);
        }

        public IList<TEntity> Query(Expression<Func<TEntity, bool>> predicate, Action<Orderable<TEntity>> orderBy, int startRow, int maxRows, bool lazyLoad = false)
        {
            return Transact<IList<TEntity>>(rep =>
            {
                return rep.Query<TEntity>(predicate, orderBy,startRow,maxRows).ToList();
            }
            ,lazyLoad);
        }
        public IList<TEntity> Query(Action<Orderable<TEntity>> orderBy, int startRow, int maxRows, bool lazyLoad = false)
        {
            return Query(null, orderBy, startRow, maxRows, lazyLoad);
        }

        public void Create(TEntity entity)
        {
            Transact(rep => rep.Create(entity));
        }

        public void Update(TEntity entity)
        {
            Transact(rep => rep.Update(entity));
        }

        public void Update(Expression<Func<TEntity,bool>> predicate,Action<TEntity> handler)
        {
            Transact(rep =>
            {
                var entity= rep.Get<TEntity>(predicate);
                if(entity!=null)
                {
                    handler(entity);
                }
            });
        }

        public void CreateOrUpdate(TEntity entity)
        {
            var orign=GetByID(entity.ID);
            if (orign != null)
            {
                Update(entity);
            }
            else
            {
                Create(entity);
            }
        }

    }
}
