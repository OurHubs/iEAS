using iEAS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.BaseData
{
    public class BaseDataItemService : IdentityDomainService<BaseDataItem, iEASRepository>, IBaseDataItemService
    {
    }
}
