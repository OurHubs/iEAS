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
        /// 获取用户的权限信息
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public IEnumerable<Permission> GetUserPermissions(int userID)
        {
            List<Permission> results = new List<Permission>();

            IUserService userService = ObjectContainer.GetService<IUserService>();
            IPermissionService permissionService = ObjectContainer.GetService<IPermissionService>();

            using (var ctx = permissionService.BeginContext())
            {
                userService.JoinContext(ctx);

                User user = userService.GetByID(userID);

                var userPermissions = permissionService.GetPermissions("USER", user.Guid.ToString());
                
                string[] roleGuids = user.Roles.Select(m => m.Guid.ToString()).ToArray();
                var rolePermissions = permissionService.GetPermissions("ROLE", roleGuids);

                results.AddRange(userPermissions);
                results.AddRange(rolePermissions);
            }
            return results.Distinct();
        }

        /// <summary>
        /// 获取用户权限信息
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public IEnumerable<Permission> GetUserPermissions(Guid guid)
        {
            List<Permission> results = new List<Permission>();

            IUserService userService = ObjectContainer.GetService<IUserService>();
            IPermissionService permissionService=ObjectContainer.GetService<IPermissionService>();

            using(var ctx=permissionService.BeginContext())
            {
                userService.JoinContext(ctx);

                var userPermissions = permissionService.GetPermissions("USER", guid.ToString());


                User user=userService.GetByGuid(guid);
                string[] roleGuids = user.Roles.Select(m => m.Guid.ToString()).ToArray();
                var rolePermissions = permissionService.GetPermissions("ROLE", roleGuids);

                results.AddRange(userPermissions);
                results.AddRange(rolePermissions);
            }
            return results.Distinct();

        }

        /// <summary>
        /// 获取权限列表
        /// </summary>
        /// <param name="ownerType"></param>
        /// <param name="ownerID"></param>
        /// <param name="resourceType"></param>
        /// <returns></returns>
        public IEnumerable<Permission> GetPermissions(string ownerType, string ownerID)
        {
            return this.Query(m => m.OwnerType == ownerType && m.OwnerID == ownerID && m.Status == 1, null).ToList();
        }


        /// <summary>
        /// 获取权限列表
        /// </summary>
        /// <param name="ownerType"></param>
        /// <param name="ownerIds"></param>
        /// <param name="resourceType"></param>
        /// <returns></returns>
        public IEnumerable<Permission> GetPermissions(string ownerType, IEnumerable<string> ownerIds)
        {
            return this.Query(m => m.OwnerType == ownerType && ownerIds.Contains(m.OwnerID) && m.Status == 1, null).ToList();
        }

        /// <summary>
        /// 获取权限列表
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
