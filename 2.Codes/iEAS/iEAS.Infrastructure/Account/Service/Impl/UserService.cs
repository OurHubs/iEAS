﻿using iEAS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.Account
{
    public class UserService:IdentityDomainService<User,iEASRepository>,IUserService
    {
    }
}