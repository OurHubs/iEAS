using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iEAS
{
    public static class LogManager
    {
        public static ILogger GetLogger()
        {
            return ObjectContainer.GetService<ILogger>("system");
        }
    }
}
