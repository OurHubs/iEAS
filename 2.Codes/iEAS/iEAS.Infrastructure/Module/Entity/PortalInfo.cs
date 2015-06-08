using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.Module
{
    public class PortalInfo:IdentityEntity
    {
        private List<Menu> _Menus = new List<Menu>();
        /// <summary>
        /// 名称
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
        /// 菜单
        /// </summary>
        public virtual List<Menu> Menus
        {
            get { return _Menus; }
            set { _Menus = value; }
        }
    }
}
