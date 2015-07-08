using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.Orgnization
{
    /// <summary>
    /// 汇报关系
    /// </summary>
    public class ReportLine:IdentityEntity
    {
        /// <summary>
        /// 员工ID
        /// </summary>
        public int EmployeeID { get; set; }
        /// <summary>
        /// 员工编号
        /// </summary>
        public string EmployeeNumber { get; set; }
        /// <summary>
        /// 上级ID
        /// </summary>
        public int SuperiorID { get; set; }
        /// <summary>
        /// 上级编号
        /// </summary>
        public string SuperiorNumber { get; set; }
        /// <summary>
        /// 员工
        /// </summary>
        public virtual Employee Employee { get; set; }
        /// <summary>
        /// 上级
        /// </summary>
        public virtual Employee Superior { get; set; }
    }
}
