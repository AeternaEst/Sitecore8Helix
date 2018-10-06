using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Sitecore8Helix.Feature.Products.Handles;
using Sitecore8Helix.Foundation.Search.Constants;
using Sitecore8Helix.Foundation.Search.Interfaces;
using Sitecore8Helix.Foundation.Search.Models;

namespace Sitecore8Helix.Feature.Products.Controllers
{
    public class ProductsController : Controller
    {

        protected SearchProductsHandle ProductsHandle;
        protected SearchSolrNetProductsHandle SolrNetProductsHandle;
        protected ISearchService SearchService;

        public ProductsController(SearchProductsHandle productsHandle,
            SearchSolrNetProductsHandle solrNetProductsHandle, ISearchService searchService)
        {
            ProductsHandle = productsHandle;
            SolrNetProductsHandle = solrNetProductsHandle; 
            SearchService = searchService;
        }

        public ActionResult Products()
        {
            var result = ProductsHandle.Handle(new SearchQuery
            {
                SearchText = HttpContext.Request.QueryString[SearchConstants.QueryString.SearchTextName],
                Filters = SearchService.GetSelectedFilters(HttpContext.Request.QueryString),
                TemplateName = SearchConstants.Templates.ProductTemplateName,
                Language = Sitecore.Context.Language.ToString(),
                Facets = SearchService.GetSelectedFacets(Sitecore.Context.Item),
                ContextDatabase = Sitecore.Context.Database.Name
            });

            return View(result);
        }

        public ActionResult SolrNetProducts()
        {
            var result = SolrNetProductsHandle.Handle(new SearchQuery
            {
                SearchText = HttpContext.Request.QueryString[SearchConstants.QueryString.SearchTextName],
                Filters = SearchService.GetSelectedFilters(HttpContext.Request.QueryString),
                TemplateName = SearchConstants.Templates.ProductTemplateName,
                Language = Sitecore.Context.Language.ToString(),
                Facets = SearchService.GetSelectedFacets(Sitecore.Context.Item),
                ContextDatabase = Sitecore.Context.Database.Name
            });

            return View("~/Views/Products/Products.cshtml", result);
        }
    }
}