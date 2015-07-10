using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.Module
{
    public class UserDesptopUC: BaseEntity
    {
        /// <summary>
        /// 用户Recode
        /// </summary>
        public string UserGUI { get; set; }

        /// <summary>
        /// 控件类型
        /// </summary>
        public string DestopUCType { get; set; }

        /// <summary>
        /// 存放所有控件的编号
        /// </summary>
        public string UCCodes { get; set; }
    }
}
