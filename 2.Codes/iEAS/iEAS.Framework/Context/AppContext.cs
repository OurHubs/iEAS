using Autofac;
using Autofac.Integration.Web;
using iEAS.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace iEAS
{
    public class AppContext
    {
        private static readonly AppContext _ctx = new AppContext();
        private AppContext() { }

        public static AppContext Current
        {
            get
            {
                return _ctx;
            }
        }

        public UserInfo User
        {
            get
            {
                //UserInfo user=HttpContext.Current.Session[typeof(UserInfo).FullName] as UserInfo;
                //if (user == null)
                //    throw new AuthorizationException();
                //return user;
                return new UserInfo();
            }
        }
    }
}
