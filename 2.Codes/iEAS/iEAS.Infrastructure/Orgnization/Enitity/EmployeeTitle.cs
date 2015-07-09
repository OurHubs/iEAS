using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.Orgnization
{
    /// <summary>
    /// 员工职称信息
    /// </summary>
    public class EmployeeTitle : IdentityEntity
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
        /// 职称ID
        /// </summary>
        public Guid TitleID { get; set; }
        /// <summary>
        /// 职称编码
        /// </summary>
        public string TitleCode { get; set; }
        /// <summary>
        /// 员工
        /// </summary>
        public virtual Employee Employee { get; set; }
        /// <summary>
        /// 职位
        /// </summary>
        public virtual Title Title { get; set; }
    }
}
