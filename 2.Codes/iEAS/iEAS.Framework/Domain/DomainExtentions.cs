using System;
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
            entity.Updator = CurrentUser.Guid.ToString();
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
            entity.Creator = CurrentUser.Guid.ToString();
            entity.CreateTime = DateTime.Now;
            entity.Updator = CurrentUser.Guid.ToString();
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
