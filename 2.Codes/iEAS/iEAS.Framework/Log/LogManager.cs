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
            return ObjectContainer.Resolve<ILogger>("system");
        }

        public static ILogger GetDBLogger()
        {
            return ObjectContainer.Resolve<ILogger>("dblog");
        }

        public static  ILogger GetFileLogger()
        {
            log4net.LogManager.GetLogger("");
            return ObjectContainer.Resolve<ILogger>("filelog");
        }
    }
}
