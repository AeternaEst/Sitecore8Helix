﻿using System.Collections.Generic;
using System.Linq;
using Sitecore.ContentSearch.Utilities;
using Sitecore.DependencyInjection;
using Sitecore8Helix.Website.Interfaces;
using Sitecore8Helix.Website.Models;
using SolrNet;
using SolrNet.Commands.Parameters;

namespace Sitecore8Helix.Website.Handles
{
    public class SearchSolrNetProductsHandle : IHandle<SearchProductsQuery, Product, SearchResult<Product>>
    {
        public SearchResult<Product> Handle(SearchProductsQuery query)
        {
            var solr = Microsoft.Practices.ServiceLocation.ServiceLocator.Current.GetInstance<ISolrOperations<ProductSearchResultItem>>();

            //Text search
            AbstractSolrQuery solrQuery = string.IsNullOrEmpty(query.SearchText) ? SolrQuery.All :
                new SolrQueryBoost(new SolrQueryByField("product_title_t", query.SearchText), 2.0) ||
                    new SolrQueryByField("product_description_t", query.SearchText); 

            //Default filters that is always applied
            var filters = new List<ISolrQuery>
            {
                new SolrQueryByField("_language", query.Language),
                new SolrQueryByField("_templatename", query.TemplateName),
                new SolrNotQuery(new SolrQueryByField("_name", "__Standard Values"))
            };

            string keepFacetName = null;
            //User applied filters
            if (query.Filters.Any())
            {
                var index = 0;
                query.Filters.ForEach(filter =>
                {
                    ISolrQuery t = new SolrQueryInList(filter.Key, filter.Value);

                    if (++index == query.Filters.Count())
                    {
                        keepFacetName = filter.Key;
                        t = new LocalParams.LocalParamsQuery(t, new LocalParams(new Dictionary<string, string> { { "tag", "keepfacet" } }));
                    }

                    filters.Add(t);
                });
            }

            var options = new QueryOptions();
            options.FilterQueries = filters;

            //Selected facets
            if (query.Facets.Any())
            {
                var facets = new List<ISolrFacetQuery>();
                query.Facets.ForEach(facet =>
                {
                    var facetPrefix = keepFacetName != null && keepFacetName == facet.Key ? "{!ex=keepfacet}" : string.Empty; 
                    facets.Add(new SolrFacetFieldQuery(facetPrefix + facet.Key)
                    {
                        MinCount = facet.Value
                    });
                });
                options.AddFacets(facets.ToArray());
            }

            var results = solr.Query(solrQuery, options);

            return new SearchResult<Product>
            {
                Hits = results.NumFound,
                Results = results.Select(result => new Product
                {
                    Title = result.Title.First(),
                    Description = result.Description.First(),
                    Type = result.Type,
                    Category = result.Category,
                    Price = result.Price,
                    Rating = result.Rating,
                    IntroDate = result.IntroDate
                }),
                FacetResults = results.FacetFields.Select(facet => new Facet
                {
                    Key = facet.Key,
                    Values = facet.Value.Select(facetValue => new FacetValue
                    {
                        Key = facetValue.Key,
                        Count = facetValue.Value
                    })
                })
            };
        }
    }
}