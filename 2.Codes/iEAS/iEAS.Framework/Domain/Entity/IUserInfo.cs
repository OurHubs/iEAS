using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iEAS
{
    public interface IUserInfo
    {
        int ID { get; set; }

        Guid Guid { get; set; }

        string Name { get; set; }
    }
}
