using iEAS.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.Context
{
    public class PortalContext
    {
        private static PortalContext _Context;
        private Dictionary<string, PortalInfo> DictPortal = new Dictionary<string, PortalInfo>();

        public static PortalContext Current
        {
            get
            {
                if(_Context==null)
                {
                    _Context = new PortalContext();
                }
                return _Context;
            }
        }

        /// <summary>
        /// 获取当前的Portal信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public PortalInfo GetPortal(string code)
        {
            if(!DictPortal.ContainsKey(code))
            {
                IPortalService service = ObjectContainer.GetService<IPortalService>();
                PortalInfo portal = service.Get(m => m.Code == code && m.Status == 1,true);
                if(portal==null)
                {
                    throw new BusinessException("Portal="+code+"的Portal不存在！");
                }
                portal.Menus.RemoveAll(m => m.Status != 1);
                DictPortal.Add(code, portal);
            }
            return DictPortal[code];
        }

        /// <summary>
        /// 重置Portal
        /// </summary>
        public void ResetPortal()
        {
            DictPortal.Clear();
        }
    }
}
