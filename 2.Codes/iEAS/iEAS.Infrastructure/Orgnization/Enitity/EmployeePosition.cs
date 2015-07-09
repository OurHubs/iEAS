using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.Orgnization
{
    /// <summary>
    /// 员工职位信息
    /// </summary>
    public class EmployeePosition:IdentityEntity
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
        /// 部门编码
        /// </summary>
        public Guid DepartmentID { get; set; }
        /// <summary>
        /// 部门编码
        /// </summary>
        public string DepartmentCode { get; set; }
        /// <summary>
        /// 职位ID
        /// </summary>
        public Guid PositionID { get; set; }
        /// <summary>
        /// 职位编码
        /// </summary>
        public string PositionCode { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        public virtual Department Department { get; set; }
        /// <summary>
        /// 员工
        /// </summary>
        public virtual Employee Employee { get; set; }
        /// <summary>
        /// 职位
        /// </summary>
        public virtual Position Position { get; set; }
    }
}
