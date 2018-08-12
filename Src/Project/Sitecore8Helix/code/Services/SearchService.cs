using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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

        public IEnumerable<KeyValuePair<string, List<string>>> GetSelectedFilters(NameValueCollection queryString)
        {
            var selectedFilters = new List<KeyValuePair<string, List<string>>>();

            var filters = queryString["Filters"];

            if(string.IsNullOrEmpty(filters))
                return selectedFilters;

            //?Filters=country_s=Denmark,Sweden|city_s=Copenhagen,Lyngby|store_type=Retail,Popup&searchText=funiture

            var qFilters = filters.Split(new[] {'|'});

            foreach (var filter in qFilters)
            {
                var values = filter.Split(new[] {'='});

                if (values.Length == 2)
                {
                    var pair = new KeyValuePair<string, List<string>>(values[0], new List<string>());
                    var t = values[1].Split(new[] {','});
                    foreach (var p in t)
                    {
                        pair.Value.Add(p);
                    }
                    selectedFilters.Add(pair);
                }
            }

            return selectedFilters;
        }
    }
}