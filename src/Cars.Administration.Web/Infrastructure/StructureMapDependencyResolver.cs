using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Cars.Administration.Web.Helpers;
using StructureMap;

namespace Cars.Administration.Web.Infrastructure
{
    public class StructureMapDependencyResolver: IDependencyResolver
    {
        private readonly Func<IContainer> _containerFactory;

        public StructureMapDependencyResolver(Func<IContainer> containerFactory)
        {
            _containerFactory = containerFactory;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType.IsNull())
                return null;

            var container = _containerFactory();

            return serviceType.IsAbstract || serviceType.IsInterface
                ? container.TryGetInstance(serviceType)
                : container.GetInstance(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            var container = _containerFactory();
            return container.GetAllInstances(serviceType).Cast<object>();
        }
    }
}