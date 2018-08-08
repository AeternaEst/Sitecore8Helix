using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Diagnostics;

namespace Sitecore8Helix.Website.Constants
{
    public static class SearchConstants
    {
        public static class Index
        {
            public static string GetSearchIndexName(string contextDb)
            {
                Assert.IsNotNullOrEmpty(contextDb, nameof(contextDb));

                return $"sitecore_{contextDb.ToLower()}_index";
            }
        }
    }
}