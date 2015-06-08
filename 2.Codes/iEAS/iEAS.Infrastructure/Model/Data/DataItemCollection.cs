using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.Model.Data
{
    [Serializable]
    public class DataItemCollection:Collection<DataItem>
    {
        /// <summary>
        /// 索引
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public DataItem this[string key]
        {
            get
            {
                return this.FirstOrDefault(m=>m.Key==key);
            }
            set
            {
                var item = this.FirstOrDefault(m => m.Key == key) ?? new DataItem();
                item.Key = value.Key;
                item.Value = value.Value;
                item.Type = value.Type;
            }
        }

        /// <summary>
        /// 获取指定Key的值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object GetValue(string key)
        {
            var item=this[key];
            return item != null ? item.Value : null;
        }

        public DbType GetType(string key)
        {
            var item = this[key];
            if(item==null)
                throw new Exception("指定的字段不存在！");
            return item.Type;
        }
    }
}
