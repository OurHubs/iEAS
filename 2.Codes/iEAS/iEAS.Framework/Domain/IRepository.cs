using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace iEAS
{
    public interface IRepository:IDisposable
    {
        /// <summary>
        /// 按指定条件查找到像
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        TEntity Get<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;

        /// <summary>
        /// 获取集合中的第一个对象
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        TEntity Get<TEntity>() where TEntity : class;

        /// <summary>
        /// 记录查询
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="orderby"></param>
        /// <returns></returns>
        IQueryable<TEntity> Query<TEntity>(Expression<Func<TEntity, bool>> predicate = null, Action<Orderable<TEntity>> orderby = null)
            where TEntity : class;

        /// <summary>
        /// 数据查询
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="orderby"></param>
        /// <param name="startRow"></param>
        /// <param name="maxRows"></param>
        /// <returns></returns>
        IQueryable<TEntity> Query<TEntity>(Expression<Func<TEntity, bool>> predicate, Action<Orderable<TEntity>> orderby, int startRow, int maxRows)
            where TEntity : class;

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="orderby"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        PagedResult<TEntity> PagedQuery<TEntity>(Expression<Func<TEntity, bool>> predicate, Action<Orderable<TEntity>> orderby, int pageIndex, int pageSize)
            where TEntity : class;

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="orderby"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        PagedResult<TEntity> PagedQuery<TEntity>(Action<Orderable<TEntity>> orderby, int pageIndex, int pageSize)
            where TEntity : class;

        /// <summary>
        /// 添加实体对象
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        void Create<TEntity>(TEntity entity) where TEntity : class;
        
        /// <summary>
        /// 添加实体对象
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        void Create<TEntity>(IEnumerable<TEntity> items) where TEntity : class;
        
        /// <summary>
        /// 更新数据实体
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        void Update<TEntity>(TEntity entity) where TEntity : class;
        
        /// <summary>
        /// 更新数据实体
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="handler"></param>
        void Update<TEntity>(Expression<Func<TEntity, bool>> predicate, Action<TEntity> handler) where TEntity : class;
        
        /// <summary>
        /// 删除记录
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        void Delete<TEntity>(TEntity entity) where TEntity : class;
        
        /// <summary>
        /// 删除记录
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="predicate"></param>
        void Delete<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        
    }

    public interface IRepository<TEntity> :IRepository
        where TEntity:class,new()
    {
    }
}
