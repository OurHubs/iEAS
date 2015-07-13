using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.Orgnization
{
    public class DepartmentService : IdentityDomainService<Department, iEAS.Repository.iEASRepository>, IDepartmentService
    {
    }
}
