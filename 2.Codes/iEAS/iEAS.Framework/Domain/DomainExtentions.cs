﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace iEAS
{
    public static class DomainExtentions
    {
        public static TEntity BindUpdator<TEntity>(this TEntity entity) where TEntity : IdentityEntity
        {
            entity.Updator = CurrentUser.ID.ToString();
            entity.UpdateTime = DateTime.Now;
            return entity;
        }

        public static IEnumerable<TEntity> AllBindUpdator<TEntity>(this IEnumerable<TEntity> entities)
            where TEntity : IdentityEntity
        {
            foreach(var item in entities)
            {
                item.BindUpdator();
            }
            return entities;
        }

        public static TEntity BindCreator<TEntity>(this TEntity entity)
            where TEntity:IdentityEntity
        {
            entity.Creator = CurrentUser.ID.ToString();
            entity.CreateTime = DateTime.Now;
            entity.Updator = CurrentUser.ID.ToString();
            entity.UpdateTime = entity.CreateTime;
            return entity;
        }


        public static IEnumerable<TEntity> AllBindCreator<TEntity>(this IEnumerable<TEntity> entities)
            where TEntity:IdentityEntity
        {
            foreach (var item in entities)
            {
                item.BindCreator();
            }
            return entities;
        }

        public static TEntity Deleted<TEntity>(this TEntity entity)
           where TEntity : IdentityEntity
        {
            entity.Status = 2;
            entity.BindUpdator();
            return entity;
        }

        public static IEnumerable<TEntity> AllDeleted<TEntity>(this IEnumerable<TEntity> entities)
            where TEntity :IdentityEntity
        {
            foreach(var entity in entities)
            {
                Deleted(entity);
            }
            return entities;
        }

        public static TService GetService<TService>(this BaseRepository repository) where TService:IContextService
        {
            TService service=ObjectContainer.GetService<TService>();
            service.JoinContext(repository);
            return service;
        }

        public static PagedResult<TEntity> PagedQuery<TEntity>(this IQueryable<TEntity> query,Action<Orderable<TEntity>> orderBy,int pageIndex,int pageSize=10)
        {
            PagedResult<TEntity> result = new PagedResult<TEntity>();
            result.RecordCount = query.Count();
            if(orderBy!=null)
            {
                Orderable<TEntity> order=new Orderable<TEntity>(query);
                orderBy(order);
                query=order.Query;
            }
            int start = (pageIndex - 1) * pageSize;
            result.Items = query.Skip(start).Take(pageSize).ToList();
            return result;
        }

        private static IUserInfo CurrentUser
        {
            get
            {
                IUserInfo userInfo=HttpContext.Current.Items[typeof(DomainExtentions)] as IUserInfo;
                if(userInfo==null)
                {
                    userInfo=ObjectContainer.GetService<ICurrentUserProvider>().GetCurrentUserInfo();
                    HttpContext.Current.Items[typeof(DomainExtentions)]=userInfo;
                }
                return userInfo;
            }
        }
    }
}
