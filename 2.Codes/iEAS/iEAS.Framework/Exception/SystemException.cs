using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iEAS
{
    public class SystemException:Exception
    {
        public SystemException()
            : base()
        {

        }

        public SystemException(string message)
            :base(message)
        {

        }
    }
}
