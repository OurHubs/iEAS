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
        private List<Position> _Positions = new List<Position>();
        /// <summary>
        /// 中文名
        /// </summary>
        public string Name { get; set; }
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
        public Guid? PrincipalID { get; set; }
        /// <summary>
        /// 主负责人员工编号
        /// </summary>
        public string PrincipalNumber { get; set; }
        /// <summary>
        /// 第一副负责人ID
        /// </summary>
        public Guid? DeputyID { get; set; }
        /// <summary>
        /// 第一副负责人员工编号
        /// </summary>
        public string DeputyNumber { get; set; }
        /// <summary>
        /// 上级ID
        /// </summary>
        public Guid? ParentID { get; set; }
        /// <summary>
        /// 公司ID
        /// </summary>
        public Guid? CompanyID { get; set; }
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
        /// <summary>
        /// 岗位
        /// </summary>
        public virtual List<Position> Positions
        {
            get { return _Positions; }
            set { _Positions = value; }
        }
    }
}
