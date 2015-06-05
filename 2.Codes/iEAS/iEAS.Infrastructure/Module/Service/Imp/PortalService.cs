using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iEAS.Repository;

namespace iEAS.Module
{
    public class PortalService : IdentityDomainService<PortalInfo, iEASRepository>, IPortalService
    {
        /// <summary>
        /// 根据Code查询Portal
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public PortalInfo GetPortalByCode(string code)
        {
            return this.Get(m => m.Code == code && m.Status == 1);
        }
    }
}
