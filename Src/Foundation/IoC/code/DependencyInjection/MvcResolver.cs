using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;

namespace Sitecore8Helix.Foundation.IoC.DependencyInjection
{
    public class MvcResolver : IDependencyResolver
    {
        protected IContainer Container;

        public MvcResolver(IContainer container)
        {
            Container = container;
        }

        public object GetService(Type serviceType)
        {
            return null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return null;
        }
    }
}