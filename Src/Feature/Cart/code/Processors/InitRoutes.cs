using Sitecore.Diagnostics;
using Sitecore.Pipelines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace Sitecore8Helix.Feature.Cart.Processors
{
    public class InitRoutes
    {
        public virtual void Process(PipelineArgs args)
        {
            Assert.ArgumentNotNull(args, "args");
            RegisterRoutes(RouteTable.Routes, args);
        }

        protected virtual void RegisterRoutes(RouteCollection routes, PipelineArgs args)
        {
            routes.MapHttpRoute("Cart", "api/cart/{action}", new
            {
                Controller = "ApiCart"
            });
        }
    }
}