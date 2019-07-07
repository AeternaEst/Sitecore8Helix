using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Ninject.Web.Mvc;
using Sitecore8Helix.Foundation.IoC.DependencyInjection;
using System.Web.Http;
using Sitecore8Helix.Foundation.IoC.Resolvers;

namespace Sitecore8Helix.Foundation.IoC.Init
{
    public static class InitDependencyInjection
    {
        public static void Init()
        {
            var kernel = Registration.GetKernel();
            var resolver = new NinjectDependencyResolver(kernel);
            var apiResolver = new ApiResolver(kernel);

            System.Web.Mvc.DependencyResolver.SetResolver(resolver);
            GlobalConfiguration.Configuration.DependencyResolver = apiResolver;
        }
    }
}