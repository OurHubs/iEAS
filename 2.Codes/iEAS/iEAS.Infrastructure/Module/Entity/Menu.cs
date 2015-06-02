using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.Module
{
    /// <summary>
    /// 菜单
    /// </summary>
    public class Menu:IdentityEntity
    {
        private List<Menu> _Children = new List<Menu>();
        /// <summary>
        /// 类型ID
        /// </summary>
        public int PortalID { get; set; }
        /// <summary>
        /// 上级ID
        /// </summary>
        public int? ParentID { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public virtual PortalInfo Portal { get; set; }
        /// <summary>
        /// 上级
        /// </summary>
        public virtual Menu Parent { get; set; }
        /// <summary>
        /// 子菜单
        /// </summary>
        public virtual List<Menu> Children
        {
            get { return _Children; }
            set { _Children = value; }
        }
    }
}
