using Sitecore8Helix.Foundation.Search.Constants;
using Sitecore8Helix.Foundation.Search.Interfaces;
using Sitecore8Helix.Foundation.Search.Models;
using System.Web;
using System.Web.Http;
using Sitecore.Data;
using Sitecore8Helix.Foundation.Search.Handles;

namespace Sitecore8Helix.Feature.Products.Controllers
{
    public class ApiProductsController : ApiController
    {
        protected SearchProductsHandle ProductsHandle;
        protected SearchSolrNetProductsHandle SolrNetProductsHandle;
        protected ISearchService SearchService;

        public ApiProductsController(SearchProductsHandle productsHandle,
            SearchSolrNetProductsHandle solrNetProductsHandle, ISearchService searchService)
        {
            ProductsHandle = productsHandle;
            SearchService = searchService;
            SolrNetProductsHandle = solrNetProductsHandle;
        }

        [HttpGet]
        public IHttpActionResult Search()
        {
            var searchMode = HttpContext.Current.Request.QueryString[SearchConstants.QueryString.UseSolrNet];
            var searchQuery = new SearchQuery
            {
                SearchText = HttpContext.Current.Request.QueryString[SearchConstants.QueryString.SearchTextName],
                Filters = SearchService.GetSelectedFilters(HttpContext.Current.Request.QueryString),
                TemplateName = SearchConstants.Templates.ProductTemplateName,
                Language = Sitecore.Context.Language.ToString(),
                Facets = SearchService.GetSelectedFacets(Sitecore.Context.Database.GetItem(new ID(SearchConstants.Items.ProductsSearchPageId))),
                ContextDatabase = Sitecore.Context.Database.Name
            };
            SearchResult<Product> searchResults = null;

            if (string.IsNullOrEmpty(searchMode))
            {
                searchResults = ProductsHandle.Handle(searchQuery);
            }
            else
            {
                searchResults = SolrNetProductsHandle.Handle(searchQuery);
            }

            return Json(searchResults);
        }
    }
}