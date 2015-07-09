using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iEAS
{
    public interface IUserInfo
    {
        Guid ID { get; set; }

        string Name { get; set; }
    }
}
