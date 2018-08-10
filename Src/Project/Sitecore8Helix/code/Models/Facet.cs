using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore8Helix.Website.Models
{
    public class Facet
    {
        public string Key { get; set; }
        public IEnumerable<FacetValue> Values { get; set; }
    }

    public class FacetValue
    {
        public string Key { get; set; }
        public int Count { get; set; }
    }
}