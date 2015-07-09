using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.Orgnization
{
    public class EmergencyContact:IdentityEntity
    {
        /// <summary>
        /// 员工ID
        /// </summary>
        public Guid EmployeeID { get; set; }
        /// <summary>
        /// 员工编号
        /// </summary>
        public string EmployeeNumber { get; set; }
        /// <summary>
        /// 联系人名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 与联系人的关系
        /// </summary>
        public string Relation { get; set; }
        /// <summary>
        /// 与联系人的关系
        /// </summary>
        public string RelationName { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Telephone { get; set; }
        /// <summary>
        /// 联系人邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 联系人地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 描述信息
        /// </summary>
        public string Desc { get; set; }

        public virtual Employee Employee { get; set; }

    }
}
