using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.Orgnization
{
    /// <summary>
    /// 部门
    /// </summary>
    public class Department : IdentityEntity
    {
        private List<Department> _Children = new List<Department>();
        /// <summary>
        /// 中文名
        /// </summary>
        public string ChineseName { get; set; }
        /// <summary>
        /// 英文名
        /// </summary>
        public string EngilishName { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Desc { get; set; }
        /// <summary>
        /// 主负责人ID
        /// </summary>
        public int? PrincipalManagerID { get; set; }
        /// <summary>
        /// 主负责人员工编号
        /// </summary>
        public string PrincipalManagerEmployeeNumber { get; set; }
        /// <summary>
        /// 上级ID
        /// </summary>
        public int? ParentID { get; set; }
        /// <summary>
        /// 公司ID
        /// </summary>
        public int? CompanyID { get; set; }
        /// <summary>
        /// 主负责人
        /// </summary>
        public virtual Employee PrincipalManager { get; set; }
        /// <summary>
        /// 公司
        /// </summary>
        public virtual Company Company { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        public virtual Department Parent { get; set; }

        public virtual List<Department> Children
        {
            get { return _Children; }
            set { _Children = value; }
        }
    }
}
