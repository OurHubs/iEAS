using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.Account
{
    /// <summary>
    /// 权限
    /// </summary>
    public class Permission:IdentityEntity
    {
        /// <summary>
        /// 拥有者ID
        /// </summary>
        public string OwnerID { get; set; }

        /// <summary>
        /// 拥有者类型
        /// </summary>
        public string OwnerType { get; set; }

        /// <summary>
        /// 资源ID
        /// </summary>
        public string ResouceID { get; set; }

        /// <summary>
        /// 资源类型
        /// </summary>
        public string ResourceType { get; set; }
    }
}
