using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.Module
{
    /// <summary>
    /// Desptop 用户控件
    /// </summary>
    public class DesptopUC : BaseEntity
    {
        /// <summary>
        /// 控件标题
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 控件Code
        /// </summary>
        public string Code { get; set; }


        /// <summary>
        /// 控件类型
        /// </summary>
        public string UCType { get; set; }

        /// <summary>
        /// 控件描述
        /// </summary>
        public string Desc { get; set; }

    }
}
