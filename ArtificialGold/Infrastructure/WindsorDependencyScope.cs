using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;

using Castle.Windsor;

namespace ArtificialGold.Infrastructure
{
    public class WindsorDependencyScope : IDependencyScope
    {
        private readonly IWindsorContainer _container;
        private readonly IDependencyScope _scope;
        private readonly List<object> _instances = new List<object>();

        public WindsorDependencyScope(IWindsorContainer container, IDependencyScope scope)
        {
            _container = container;
            _scope = scope;
        }

        public object GetService(Type serviceType)
        {
            object service = _scope.GetService(serviceType);

            AddToScope(service);

            return service;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            var services = _scope.GetServices(serviceType);

            AddToScope(services);

            return services;
        }

        public void Dispose()
        {
            foreach (object instance in _instances)
            {
                _container.Release(instance);
            }

            _instances.Clear();
        }

        private void AddToScope(params object[] services)
        {
            if (services.Any())
            {
                _instances.AddRange(services);
            }
        }
    }
}