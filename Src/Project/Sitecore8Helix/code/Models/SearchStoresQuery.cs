using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore8Helix.Website.Interfaces;

namespace Sitecore8Helix.Website.Models
{
    public class SearchStoresQuery : IQuery
    {
        public string TemplateName { get; set; }
        public string Language { get; set; }
        public string ContextDatabase { get; set; }
        public IEnumerable<KeyValuePair<string, int>> Facets { get; set; }
    }
}