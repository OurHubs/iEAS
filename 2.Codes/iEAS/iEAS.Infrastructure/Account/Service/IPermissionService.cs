using iEAS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.Account
{
    public interface IPermissionService : IDomainService<Permission>
    {
        /// <summary>
        /// 获取用户的权限信息
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        IEnumerable<Permission> GetUserPermissions(int userID);

        /// <summary>
        /// 获取用户权限信息
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        IEnumerable<Permission> GetUserPermissions(Guid guid);


        /// <summary>
        /// 获取权限列表
        /// </summary>
        /// <param name="ownerType"></param>
        /// <param name="ownerID"></param>
        /// <param name="resourceType"></param>
        /// <returns></returns>
        IEnumerable<Permission> GetPermissions(string ownerType, string ownerID);

        /// <summary>
        /// 获取权限列表
        /// </summary>
        /// <param name="ownerType"></param>
        /// <param name="ownerIds"></param>
        /// <param name="resourceType"></param>
        /// <returns></returns>
        IEnumerable<Permission> GetPermissions(string ownerType, IEnumerable<string> ownerIds);

        /// <summary>
        /// 获取权限列表
        /// </summary>
        /// <param name="ownerType"></param>
        /// <param name="ownerID"></param>
        /// <param name="resourceType"></param>
        /// <returns></returns>
        IEnumerable<Permission> GetPermissions(string ownerType, string ownerID, string resourceType);

        /// <summary>
        /// 保存权限信息
        /// </summary>
        /// <param name="ownerType">拥有者类型</param>
        /// <param name="ownerID">拥有者ID</param>
        /// <param name="resourceType">资源类型</param>
        /// <param name="resourceIds">资源ID</param>
        void SavePermissions(string ownerType, string ownerID, string resourceType, IEnumerable<string> resourceIds, IEnumerable<string> allResourcesIds = null);
    }
}
