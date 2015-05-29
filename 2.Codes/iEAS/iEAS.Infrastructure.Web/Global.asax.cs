using Autofac;
using iEAS.Repository;
using iEAS.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace iEAS.Infrastructure.Web
{
    public class Global : iEASGlobal
    {
        protected void Application_Start(object sender, EventArgs e)
        {
        }

        protected override void RegisterComponents(ContainerBuilder builder)
        {

            builder.RegisterType<iEASRepository>().AsSelf();
            builder.RegisterGeneric(typeof(DomainService<,>)).As(typeof(IDomainService<,>));

        }
    }
}