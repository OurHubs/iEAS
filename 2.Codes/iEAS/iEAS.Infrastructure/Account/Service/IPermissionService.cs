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
        /// 获取资源列表
        /// </summary>
        /// <param name="ownerType"></param>
        /// <param name="ownerID"></param>
        /// <param name="resourceType"></param>
        /// <returns></returns>
        IEnumerable<Permission> GetPermissions(string ownerType, string ownerID, string resourceType);

        /// <summary>
        /// 保存权限信息
        /// </summary>
        /// <param name="ownerType"></param>
        /// <param name="ownerID"></param>
        /// <param name="resourceType"></param>
        /// <param name="resourceIds"></param>
        void SavePermissions(string ownerType, string ownerID, string resourceType, IEnumerable<string> resourceIds, IEnumerable<string> allResourcesIds = null);
    }
}
