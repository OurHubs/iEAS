﻿using iEAS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.Account.Service
{
    public class RoleService : IdentityDomainService<Role, iEASRepository>, IRoleService
    {
    }
}
