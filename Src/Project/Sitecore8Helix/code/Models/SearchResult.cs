using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore8Helix.Website.Models
{
    public class SearchResult<T>
    {
        public int Hits { get; set; }

        public IEnumerable<T> Results { get; set; }

        public IEnumerable<Facet> FacetResults { get; set; }
    }
}