using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq;
using Sitecore.ContentSearch.Linq.Utilities;
using Sitecore.ContentSearch.Utilities;
using Sitecore8Helix.Feature.Products.Models;
using Sitecore8Helix.Foundation.Search.Interfaces;
using Sitecore8Helix.Foundation.Search.Models;

namespace Sitecore8Helix.Feature.Products.Handles
{
    public class SearchProductsHandle : IHandle<SearchQuery, Product, SearchResult<Product>>
    {
        public SearchResult<Product> Handle(SearchQuery query)
        {
            var index = ContentSearchManager.GetIndex(Foundation.Search.Constants.SearchConstants.Index.GetSearchIndexName(query.ContextDatabase));

            SearchResults<ProductSearchResultItem> results = null;
            using (var searchContext = index.CreateSearchContext())
            {
                var q = searchContext.GetQueryable<ProductSearchResultItem>();

                //Text search
                if (!string.IsNullOrEmpty(query.SearchText))
                {
                    q = q.Where(
                            doc => doc.Title.Contains(query.SearchText) || doc.Description.Contains(query.SearchText));
                }

                //Default filters that is always applied
                q = q.Filter(x => x.Language == query.Language && x.TemplateName == query.TemplateName &&
                            !x.Name.Contains("__Standard Values"));

                //User applied filters
                if (query.Filters.Any())
                {
                    var predicate = PredicateBuilder.True<ProductSearchResultItem>();
                    query.Filters.ForEach(filter =>
                    {
                        var orPredicate = PredicateBuilder.True<ProductSearchResultItem>();
                        filter.Value.ForEach(filterValue =>
                        {
                            orPredicate = orPredicate.Or(document => ((IObjectIndexers)document)[filter.Key] == filterValue);
                        });
                        predicate = predicate.And(orPredicate);
                    });

                    q = q.Filter(predicate);
                }

                //Selected facets
                if (query.Facets.Any())
                {
                    foreach (var facet in query.Facets)
                    {
                        q = q.FacetOn(doc => facet.Key, facet.Value);
                    }
                }

                results = q.GetResults();
            }

            return new SearchResult<Product>
            {
                FacetResults = results.Facets.Categories.Select(facet => new Facet
                {
                    Key = facet.Name,
                    Values = facet.Values.Select(facetValue => new Foundation.Search.Models.FacetValue
                    {
                        Key = facetValue.Name,
                        Count = facetValue.AggregateCount
                    })
                }),
                Hits = results.TotalSearchResults,
                Results = results.Select(result => new Product
                {
                    Title  = result.Document.Title.First(),
                    Description = result.Document.Description.First(),
                    Type = result.Document.Type,
                    Category = result.Document.Category,
                    Price = result.Document.Price,
                    IntroDate = result.Document.IntroDate,
                    Rating = result.Document.Rating
                })
            };
        }
    }
}