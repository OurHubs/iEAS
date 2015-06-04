using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iEAS
{
    public interface ICurrentUserProvider
    {
        IUserInfo GetCurrentUserInfo();
    }
}
