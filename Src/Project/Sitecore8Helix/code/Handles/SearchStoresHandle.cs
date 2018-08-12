using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq;
using Sitecore.ContentSearch.Utilities;
using Sitecore8Helix.Website.Constants;
using Sitecore8Helix.Website.Interfaces;
using Sitecore8Helix.Website.Models;
using FacetValue = Sitecore8Helix.Website.Models.FacetValue;

namespace Sitecore8Helix.Website.Handles
{
    public class SearchStoresHandle : IHandle<SearchStoresQuery, Store, SearchResult<Store>>
    {
        public SearchResult<Store> Handle(SearchStoresQuery query)
        {
            var index = ContentSearchManager.GetIndex(SearchConstants.Index.GetSearchIndexName(query.ContextDatabase));
            
            SearchResults<StoreSearchResultItem> results = null;
            using (var searchContext = index.CreateSearchContext())
            {
                var q = searchContext.GetQueryable<StoreSearchResultItem>();

                //TODO: Boost Name
                if (!string.IsNullOrEmpty(query.SearchText))
                {
                    q = q.Where(document => document.StoreName.Contains(query.SearchText)
                                        || document.Description.Contains(query.SearchText));
                }

                //Default filters
                q = q.Filter(document => document.TemplateName == query.TemplateName &&
                                         document.Language == query.Language);

                //User applied filters
                query.Filters.ForEach(filter =>
                {
                    q = q.Filter(document => ((IObjectIndexers) document)[filter.Key] == filter.Value);
                });

                query.Facets.ForEach(facet =>
                {
                    q = q.FacetOn(x => facet.Key, facet.Value);
                });

                results = q.GetResults();               
            }

            var stores = results.Hits.Select(hit => new Store
            {
                Name = hit.Document.StoreName.FirstOrDefault(),
                Description = hit.Document.Description.FirstOrDefault(),
                City = hit.Document.City,
                Country = hit.Document.Country,
                Street = hit.Document.Street,
                StreetNumber = hit.Document.StreetNumber,
                Type = hit.Document.Type,
                ZipCode = hit.Document.ZipCode
            });

            var facets = results.Facets.Categories.Select(facetResult => new Facet
            {
                 Key = facetResult.Name, Values = facetResult.Values.Select(fr =>
                    new FacetValue { Key = fr.Name, Count = fr.AggregateCount})
            });

            return new SearchResult<Store>
            {
                Hits = results.TotalSearchResults,
                Results = stores,
                FacetResults = facets
            };
        }
    }
}