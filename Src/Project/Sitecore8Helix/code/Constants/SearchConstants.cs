using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;
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

        public static class Fields
        {
            public static ID FacetsField => new ID("{9AACF0E5-4C54-42E4-B7E1-16311390D70D}");
            public static ID FieldName => new ID("{0E23BB51-C071-41B5-9D83-AC410B89B85A}");
            public static ID MinimumNumOfItems => new ID("{8A3AC1B8-8CC1-4DD4-8766-9803F1601741}");
        }
    }
}