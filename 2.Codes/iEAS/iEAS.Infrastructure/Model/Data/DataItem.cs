using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.Model.Data
{
    /// <summary>
    /// 数据值
    /// </summary>
    [Serializable]
    public class DataItem
    {
        /// <summary>
        /// 键
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// 数据类型
        /// </summary>
        public DbType Type { get; set; }
    }
}
