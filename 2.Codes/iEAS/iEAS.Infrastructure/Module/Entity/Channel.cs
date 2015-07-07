using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.Module
{
    public class Channel : IdentityEntity
    {
        private List<Channel> _Children = new List<Channel>();

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
        /// 栏目类型
        /// Url：Url
        /// Model：模型
        /// Node:节点
        /// </summary>
        public string ChannelType { get; set; }
        /// <summary>
        /// 模型
        /// </summary>
        public string Model { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ModelChannel { get; set; }
        /// <summary>
        /// 页面地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 模板
        /// </summary>
        public string Template { get; set; }
        /// <summary>
        /// 描述信息
        /// </summary>
        public string Desc { get; set; }
        /// <summary>
        /// 完整名称
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// 完整路径
        /// </summary>
        public string FullPath { get; set; }
        /// <summary>
        /// 父级名称
        /// </summary>
        public string ParentName { get; set; }
        /// <summary>
        /// 父级路径
        /// </summary>
        public string ParentPath { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 上级
        /// </summary>
        public virtual Channel Parent { get; set; }
        /// <summary>
        /// 子栏目
        /// </summary>
        public virtual List<Channel> Children
        {
            get { return _Children; }
            set { _Children = value; }
        }


    }
}
