using iEAS.Framework.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iEAS
{
    public static class LogManager
    {
        private static ILogger logger = new Log4netLogger();
        public static ILogger GetLogger()
        {
            return logger;
        }
    }
}
