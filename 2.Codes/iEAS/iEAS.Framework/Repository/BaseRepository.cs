using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace iEAS.Repository
{
    public class BaseRepsitory:DbContext
    {
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
    }
}
