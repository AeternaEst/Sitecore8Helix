using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore8Helix.Foundation.Search.Utils
{
    public static class SearchUtil
    {
        public static string ExtractIdFromUniqueId(string uniqueId)
        {
            var firstBracket = uniqueId.IndexOf('{');
            var secondBracket = uniqueId.IndexOf('}');
            var lengthToSubstring = secondBracket - firstBracket;
            var extractedId = uniqueId.Substring(firstBracket + 1, (secondBracket - firstBracket) - 1);
            return extractedId;
        }
    }
}