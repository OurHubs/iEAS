using iEAS.Module;
using iEAS.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iEAS
{
    public class AppContext
    {
        private AppContext() { }

        public static AppContext Current
        {
            get
            {
                return new AppContext();
            }
        }

        public UserInfo User
        {
            get { return new UserInfo(); }
        }

        public ModuleInfo Module
        {
            get { return new ModuleInfo(); }
        }
    }
}
