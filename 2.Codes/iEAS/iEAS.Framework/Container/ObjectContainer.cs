using Autofac;
using Autofac.Features.OwnedInstances;
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
        public static ILifetimeScope ApplicationContainer
        {
            get
            {
                return ContainerBuilder.ApplicationContainer;
            }
        }

        public static ILifetimeScope RequestContainer
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
        public static TService GetService<TService>()
        {
            return RequestContainer.Resolve<TService>();
        }

        /// <summary>
        /// 根据指定的Key值获取服务对象
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static TService GetService<TService>(object key)
        {
            return RequestContainer.Resolve<TService>(new NamedParameter("key", key));
        }

        /// <summary>
        /// 从当前请求的Scope中获取服务对象
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <returns></returns>
        public static TService GetOptionalService<TService>() where TService:class
        {
            return RequestContainer.ResolveOptional<TService>();
        }

        /// <summary>
        /// 获取Owned服务对象
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <returns></returns>
        public static TService GetOwnedService<TService>() where TService:IDisposable
        {
            return RequestContainer.Resolve<Owned<TService>>().Value;
        }

        public static ILifetimeScope BeginLifetimeScope()
        {
            return ApplicationContainer.BeginLifetimeScope();
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
