using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace iEAS
{
    /// <summary>
    /// 领域服务接口
    /// </summary>
    /// <typeparam name="TRepository"></typeparam>
    public interface IDomainService
    {
        /// <summary>
        /// 加入数据上下文
        /// </summary>
        /// <typeparam name="TDbContext"></typeparam>
        /// <param name="dbContext"></param>
        void JoinContext(BaseRepository dbContext);

        /// <summary>
        /// 移除数据上下文
        /// </summary>
        void DetachContext();

        /// <summary>
        /// 从Repository中获取数据
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="handler"></param>
        /// <param name="layzLoad"></param>
        /// <returns></returns>
        TResult Fetch<TRepository, TResult>(Func<TRepository, TResult> handler, bool layzLoad = false)
            where TRepository : BaseRepository, new();

        /// <summary>
        /// 在Repository中执行数据操作
        /// </summary>
        /// <param name="handler"></param>
        void Execute<TRepository>(Action<TRepository> handler)
            where TRepository : BaseRepository, new();
    }

    /// <summary>
    /// 领域服务接口
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TRepository"></typeparam>
    public interface IDomainService<TEntity>:IContextService
    {
        /// <summary>
        /// 创建实体
        /// </summary>
        /// <param name="entity"></param>
        void Create(TEntity entity);

        /// <summary>
        /// 批量创建实体
        /// </summary>
        /// <param name="items"></param>
        void Create(IEnumerable<TEntity> items);

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity);

        /// <summary>
        /// 批量更新实体
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="handler"></param>
        void Update(Expression<Func<TEntity, bool>> predicate, Action<TEntity> handler);

        /// <summary>
        /// 按ID更新实体
        /// </summary>
        /// <param name="id"></param>
        /// <param name="handler"></param>
        void UpdateByID(Guid id, Action<TEntity> handler);

        /// <summary>
        /// 按SN更新实体
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="handler"></param>
        void UpdateBySN(int sn, Action<TEntity> handler);

        /// <summary>
        /// 创建或更新实体
        /// </summary>
        /// <param name="entity"></param>
        void CreateOrUpdate(TEntity entity);

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity"></param>
        void Delete(TEntity entity);

        /// <summary>
        /// 按条件批量删除实体
        /// </summary>
        /// <param name="predicate"></param>
        void Delete(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 按ID删除实体
        /// </summary>
        /// <param name="id"></param>
        void DeleteByID(Guid id);

        /// <summary>
        /// 按SN删除实体
        /// </summary>
        /// <param name="sn"></param>
        void DeleteBySN(int sn);

        /// <summary>
        /// 按Id获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <param name="lazyLoad"></param>
        /// <returns></returns>
        TEntity GetByID(Guid id, bool lazyLoad = false);

        /// <summary>
        /// 按SN获取实体
        /// </summary>
        /// <param name="sn"></param>
        /// <param name="lazyLoad"></param>
        /// <returns></returns>
        TEntity GetBySN(int sn, bool lazyLoad = false);

        /// <summary>
        /// 按查询条件获取实体
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="lazyLoad"></param>
        /// <returns></returns>
        TEntity Get(Expression<Func<TEntity, bool>> predicate, bool lazyLoad = false);

        /// <summary>
        /// 列表查询
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="orderBy"></param>
        /// <param name="lazyLoad"></param>
        /// <returns></returns>
        IList<TEntity> Query(Expression<Func<TEntity, bool>> predicate, Action<Orderable<TEntity>> orderBy=null, bool lazyLoad = false);

        /// <summary>
        /// 列表查询
        /// </summary>
        /// <param name="lazyLoad"></param>
        /// <returns></returns>
        IList<TEntity> QueryAll(bool lazyLoad = false);

        /// <summary>
        /// 列表查询
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="orderBy"></param>
        /// <param name="startRow"></param>
        /// <param name="maxRows"></param>
        /// <param name="lazyLoad"></param>
        /// <returns></returns>
        QueryResult<TEntity> QueryRecord(Expression<Func<TEntity, bool>> predicate, Action<Orderable<TEntity>> orderBy, int startRow, int maxRows, bool lazyLoad = false);

        /// <summary>
        /// 列表查询
        /// </summary>
        /// <param name="orderBy"></param>
        /// <param name="startRow"></param>
        /// <param name="maxRows"></param>
        /// <param name="lazyLoad"></param>
        /// <returns></returns>
        QueryResult<TEntity> QueryRecord(Action<Orderable<TEntity>> orderBy, int startRow, int maxRows, bool lazyLoad = false);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="orderBy"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        PagedResult<TEntity> PagedQuery(Expression<Func<TEntity, bool>> predicate, Action<Orderable<TEntity>> orderBy, int pageIndex, int pageSize);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="orderBy"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        PagedResult<TEntity> PagedQuery(Action<Orderable<TEntity>> orderBy, int pageIndex, int pageSize);
    }
}
