using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc;
using Sitecore.Data.Items;
using Sitecore8Helix.Foundation.Presentation.Constants;

namespace Sitecore8Helix.Foundation.Presentation.Extensions
{
    public static class ItemExtensions
    {
        public static T ToModel<T>(this Item item) where T : class
        {
            if (item == null)
                return null;

            var cacheKey = $"{PresentationConstants.CacheKeys.GlassServiceKey}{Sitecore.Context.Database}";
            var glassService = Sitecore.Context.Items[cacheKey] as SitecoreService;
            if (glassService == null)
            {
                glassService = new SitecoreService(Sitecore.Context.Database);
                Sitecore.Context.Items[cacheKey] = glassService;
            }
            return glassService.CreateType<T>(item);
        }
    }
}