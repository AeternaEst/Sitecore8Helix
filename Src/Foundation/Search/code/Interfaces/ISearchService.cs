using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data.Items;

namespace Sitecore8Helix.Foundation.Search.Interfaces
{
    public interface ISearchService
    {
        IEnumerable<KeyValuePair<string, int>> GetSelectedFacets(Item facetItem);
        IEnumerable<KeyValuePair<string, List<string>>> GetSelectedFilters(NameValueCollection queryString);
    }
}
