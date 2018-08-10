using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore8Helix.Website.Constants;

namespace Sitecore8Helix.Website.Services
{
    public class SearchService
    {
        public IEnumerable<KeyValuePair<string, int>> GetSelectedFacets(Item facetItem)
        {
            Assert.IsNotNull(facetItem, nameof(facetItem));
            var facetsField = (MultilistField)facetItem.Fields[SearchConstants.Fields.FacetsField];
            Assert.IsNotNull(facetsField, $"No Facets found on item {facetItem.ID}");

            var selectedFacets = facetsField.GetItems()?.Select(item =>
                new KeyValuePair<string, int>(item[SearchConstants.Fields.FieldName],
                int.Parse(item[SearchConstants.Fields.MinimumNumOfItems]))
            );

            return selectedFacets;
        } 
    }
}