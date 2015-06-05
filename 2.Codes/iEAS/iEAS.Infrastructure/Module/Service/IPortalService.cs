using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iEAS.Repository;

namespace iEAS.Module
{
    public interface IPortalService : IDomainService<PortalInfo>
    {
        /// <summary>
        /// 根据Code查询Portal
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        PortalInfo GetPortalByCode(string code);
    }
}
