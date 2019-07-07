using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore8Helix.Foundation.Search.Models
{
    public class Facet
    {              
        [JsonProperty("key")]
        public string Key { get; set; }
        [JsonProperty("values")]
        public IEnumerable<FacetValue> Values { get; set; }
    }

    public class FacetValue
    {
        [JsonProperty("key")]
        public string Key { get; set; }
        [JsonProperty("count")]
        public int Count { get; set; }
    }
}