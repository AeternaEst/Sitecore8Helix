using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Ninject.Web.Mvc;
using Sitecore8Helix.Foundation.IoC.DependencyInjection;

namespace Sitecore8Helix.Foundation.IoC.Init
{
    public static class InitDependencyInjection
    {
        public static void Init()
        {
            var resolver = new NinjectDependencyResolver(Registration.GetKernel());

            System.Web.Mvc.DependencyResolver.SetResolver(resolver);
        }
    }
}