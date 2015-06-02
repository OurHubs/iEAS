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

    }
}
