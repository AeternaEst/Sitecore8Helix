using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore8Helix.Foundation.Search.Models
{
    public class SearchResult<T>
    {
        [JsonProperty("hits")]
        public int Hits { get; set; }

        [JsonProperty("results")]
        public IEnumerable<T> Results { get; set; }

        [JsonProperty("facetResults")]
        public IEnumerable<Facet> FacetResults { get; set; }
    }
}