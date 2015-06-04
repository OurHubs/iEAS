using iEAS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.Account
{
    public class PermissionService : IdentityDomainService<Permission, iEASRepository>, IPermissionService
    {
        /// <summary>
        /// 获取资源列表
        /// </summary>
        /// <param name="ownerType"></param>
        /// <param name="ownerID"></param>
        /// <param name="resourceType"></param>
        /// <returns></returns>
        public IEnumerable<Permission> GetPermissions(string ownerType, string ownerID, string resourceType)
        {
            return this.Query(m => m.OwnerType == ownerType && m.OwnerID == ownerID && m.ResourceType == resourceType && m.Status == 1, null).ToList();
        }

        /// <summary>
        /// 保存权限信息
        /// </summary>
        /// <param name="ownerType"></param>
        /// <param name="ownerID"></param>
        /// <param name="resourceType"></param>
        /// <param name="resourceIds"></param>
        public void SavePermissions(string ownerType, string ownerID, string resourceType, IEnumerable<string> resourceIds,IEnumerable<string> allResourcesIds=null)
        {
            this.Execute<iEASRepository>(rep =>
                {
                    var allPermissions = rep.Query<Permission>(m => m.OwnerType == ownerType && m.OwnerID == ownerID && m.ResourceType == resourceType && m.Status == 1).ToList();
                    if(allResourcesIds!=null)
                    {
                        allPermissions = allPermissions.Where(m => allResourcesIds.Contains(m.ResouceID)).ToList();
                    }
                   
                    var removedPermissions= allPermissions.Where(m => !resourceIds.Contains(m.ResouceID));
                    removedPermissions.AllDeleted();

                    var newPermissions = resourceIds.Where(m => !allPermissions.Any(p => p.ResouceID == m)).Select(m => new Permission
                    {
                        OwnerID = ownerID,
                        OwnerType = ownerType,
                        ResourceType = resourceType,
                        ResouceID = m,
                        Status=1
                    });
                    newPermissions.AllBindUpdator();
                    rep.Create(newPermissions);
                    rep.SaveChanges();
                });
        }
    }
}
