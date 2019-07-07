using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Ninject;

namespace Sitecore8Helix.Foundation.IoC.Resolvers
{
    public class ApiResolver : IDependencyResolver
    {
        protected IKernel Kernel;

        public ApiResolver(IKernel kernel)
        {
            Kernel = kernel;
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectScope(Kernel);
        }

        public void Dispose()
        {
            
        }

        public object GetService(Type serviceType)
        {
            return Kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return Kernel.GetAll(serviceType);
            }
            catch
            {
                return null;
            }
        }
    }

    public class NinjectScope : IDependencyScope
    {
        protected IKernel Kernel;

        public NinjectScope(IKernel kernel)
        {
            Kernel = kernel;
        }

        public void Dispose()
        {
            
        }

        public object GetService(Type serviceType)
        {
            return Kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return Kernel.GetAll(serviceType);
            }
            catch
            {
                return null;
            }
        }
    }
}