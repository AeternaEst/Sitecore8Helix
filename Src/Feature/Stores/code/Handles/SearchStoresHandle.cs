﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq;
using Sitecore.ContentSearch.Linq.Utilities;
using Sitecore.ContentSearch.Utilities;
using Sitecore8Helix.Feature.Stores.Models;
using Sitecore8Helix.Foundation.Search.Constants;
using Sitecore8Helix.Foundation.Search.Interfaces;
using Sitecore8Helix.Foundation.Search.Models;
using FacetValue = Sitecore8Helix.Foundation.Search.Models.FacetValue;

namespace Sitecore8Helix.Feature.Stores.Handles
{
    public class SearchStoresHandle : IHandle<SearchQuery, Store, SearchResult<Store>>
    {
        public SearchResult<Store> Handle(SearchQuery query)
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
                if (query.Filters.Any())
                {
                    var predicate = PredicateBuilder.True<StoreSearchResultItem>();
                    query.Filters.ForEach(filter =>
                    {
                        var orPredicate = PredicateBuilder.True<StoreSearchResultItem>();
                        filter.Value.ForEach(filterValue =>
                        {
                            orPredicate = orPredicate.Or(document => ((IObjectIndexers)document)[filter.Key] == filterValue);
                        });
                        predicate = predicate.And(orPredicate);
                    });

                    q = q.Filter(predicate);
                }

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