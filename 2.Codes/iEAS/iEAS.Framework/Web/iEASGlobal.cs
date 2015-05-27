using Autofac;
using Autofac.Integration.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.Web
{
    public class iEASGlobal:System.Web.HttpApplication,IContainerProviderAccessor
    {
        private static IContainerProvider _ContainerProvider;

        public iEASGlobal()
        {
            BuildContainer();
        }

        public IContainerProvider ContainerProvider
        {
            get { return _ContainerProvider; }
        }

        protected void BuildContainer()
        {
            var builder = new ContainerBuilder();
            RegisterComponents(builder);
            var applicationContainer = builder.Build();
            _ContainerProvider = new ContainerProvider(applicationContainer);
        }

        protected virtual void RegisterComponents(ContainerBuilder builder)
        {

        }
    }
}
