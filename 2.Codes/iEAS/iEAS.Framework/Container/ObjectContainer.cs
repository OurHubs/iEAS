using Autofac;
using Autofac.Integration.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace iEAS
{
    public static class ObjectContainer
    {
        public static ILifetimeScope RootLifetime
        {
            get
            {
                return ContainerBuilder.ApplicationContainer;
            }
        }

        public static ILifetimeScope RequestLifetime
        {
            get
            {
                return ContainerBuilder.RequestLifetime;
            }
        }

        /// <summary>
        /// 从当前请求的Scope中获取服务对象
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <returns></returns>
        public static TService Resolve<TService>()
        {
            return RequestLifetime.Resolve<TService>();
        }

        /// <summary>
        /// 从当前请求的Scope中获取服务对象
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <returns></returns>
        public static TService ResolveOptional<TService>() where TService:class
        {
            return RequestLifetime.ResolveOptional<TService>();
        }

        static IContainerProvider ContainerBuilder
        {
            get
            {
                IContainerProviderAccessor accessor = HttpContext.Current.ApplicationInstance as IContainerProviderAccessor;

                if (accessor == null)
                    throw new Exception("Application对象没有实现IContainerProviderAccessor接口！");

                return accessor.ContainerProvider;
            }
        }
    }
}
