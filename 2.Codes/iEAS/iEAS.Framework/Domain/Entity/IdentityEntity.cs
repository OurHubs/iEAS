using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iEAS.Domain
{
    /// <summary>
    /// 带有身份信息的实体对象
    /// </summary>
    public class IdentityEntity:BaseEntity
    {
        /// <summary>
        /// 创建者
        /// </summary>
        public string Creator { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 更新者
        /// </summary>
        public string Updator { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 状态（0:草稿，1：有效，2：无效，其它的自定义）
        /// </summary>
        public int Status { get; set; }
    }
}
