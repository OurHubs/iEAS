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
        public Guid PortalID { get; set; }
        /// <summary>
        /// 上级ID
        /// </summary>
        public Guid? ParentID { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 页面地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 描述信息
        /// </summary>
        public string Desc { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get;set; }
        /// <summary>
        /// 类型
        /// </summary>
        public virtual PortalInfo Portal { get; set; }
        /// <summary>
        /// 上级
        /// </summary>
        public virtual Menu Parent { get; set; }


        public virtual List<Menu> Children
        {
            get { return _Children; }
            set { _Children = value; }
        }
    }
}
