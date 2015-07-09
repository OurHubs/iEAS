using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.Module
{
    public class Feature:IdentityEntity
    {
        private List<Feature> _Children = new List<Feature>();

        /// <summary>
        /// 模块ID
        /// </summary>
        public Guid ModuleID { get; set; }

        /// <summary>
        /// 上级功能ID
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
        /// 描述
        /// </summary>
        public string Desc { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 模块
        /// </summary>
        public virtual ModuleInfo Module { get; set; }

        /// <summary>
        /// 上级功能
        /// </summary>
        public virtual Feature Parent { get; set; }

        /// <summary>
        /// 下级功能列表
        /// </summary>
        public virtual List<Feature> Children
        {
            get { return _Children; }
            set { _Children = value; }
        }
    }
}
