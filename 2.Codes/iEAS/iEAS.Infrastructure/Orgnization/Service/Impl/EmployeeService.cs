using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.Orgnization
{
    public class EmployeeService : IdentityDomainService<Employee, iEAS.Repository.iEASRepository>, IEmployeeService
    {
    }
}
