using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;

using Castle.Windsor;

namespace ArtificialGold.Infrastructure
{
    public class WindsorDependencyResolver : IDependencyResolver
    {
        private readonly IWindsorContainer _container;

        public WindsorDependencyResolver(IWindsorContainer container)
        {
            _container = container;
        }

        public object GetService(Type serviceType)
        {
            if (_container.Kernel.HasComponent(serviceType))
            {
                return _container.Resolve(serviceType);
            }

            return null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _container.ResolveAll(serviceType).Cast<object>();
        }

        public IDependencyScope BeginScope()
        {
            return new WindsorDependencyScope(_container, this);
        }

        public void Dispose()
        {
            _container.Dispose();
        }
    }
}