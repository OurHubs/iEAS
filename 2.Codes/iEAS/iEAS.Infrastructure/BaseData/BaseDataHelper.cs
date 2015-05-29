using iEAS.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.BaseData
{
    public class BaseDataHelper
    {
        /// <summary>
        /// 从数据类型中
        /// </summary>
        /// <param name="typeCode"></param>
        /// <returns></returns>
        public static IEnumerable<BaseDataItem> GetBaseData(string typeCode)
        {
            return GetAllBaseData(typeCode).Where(m => m.Status == 1).OrderBy(m => m.ID);
        }

        public static IEnumerable<BaseDataItem> GetBaseDataRoots(string typeCode)
        {
            var items = GetBaseData(typeCode);
            var roots = items.Where(m => m.ParentID == null);
            return roots;
        }

        public static BaseDataItem GetBaseDataByName(string typeCode,string name)
        {
            return GetBaseData(typeCode).FirstOrDefault(m => m.Name==name);
        }

        public static BaseDataItem GetBaseDataByValue(string typeCode, string value)
        {
            return GetBaseData(typeCode).FirstOrDefault(m => m.Value == value);
        }

        public static BaseDataItem GetBaseDataByID(int id)
        {
            return ObjectContainer.GetService<IBaseDataItemService>().GetByID(id,true);
        }

        public static BaseDataItem GetBaseDataByGuid(Guid id)
        {
            return ObjectContainer.GetService<IBaseDataItemService>().GetByGuid(id, true);
        }

        public static IEnumerable<BaseDataItem> GetAllBaseData(string typeCode)
        {
            return CacheHelper.Get<IEnumerable<BaseDataItem>>("BaseDataItem_" + typeCode, () =>
            {
                return ObjectContainer.GetService<IBaseDataItemService>().Query(m => m.Type.Code == typeCode, o => o.Asc(m => m.ID), true);
            });
        }

        public static void ClearBaseDataCache(string typeCode)
        {
            CacheHelper.Remove("BaseDataItem_" + typeCode);
        }
    }
}
