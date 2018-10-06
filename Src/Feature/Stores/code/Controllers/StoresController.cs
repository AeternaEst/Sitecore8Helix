using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore8Helix.Feature.Stores.Constants;
using Sitecore8Helix.Feature.Stores.Handles;
using Sitecore8Helix.Foundation.Search.Constants;
using Sitecore8Helix.Foundation.Search.Interfaces;
using Sitecore8Helix.Foundation.Search.Models;

namespace Sitecore8Helix.Feature.Stores.Controllers
{
    public class StoresController : Controller
    {

        protected ISearchService SearchService;
        protected SearchStoresHandle StoresHandle;

        public StoresController(ISearchService searchService, SearchStoresHandle storesHandle)
        {
            SearchService = searchService;
            StoresHandle = storesHandle;
        }

        public ActionResult Stores()
        {
            ViewBag.Title = Sitecore.Context.Item[StoreConstants.Fields.HeadlineId];
            ViewBag.Text = Sitecore.Context.Item[StoreConstants.Fields.TextId];

            var result = StoresHandle.Handle(new SearchQuery
            {
                Language = Sitecore.Context.Language.ToString(),
                TemplateName = SearchConstants.Templates.StoreTemplateName,
                ContextDatabase = Sitecore.Context.Database.Name,
                Facets = SearchService.GetSelectedFacets(Sitecore.Context.Item),
                Filters = SearchService.GetSelectedFilters(HttpContext.Request.QueryString),
                SearchText = HttpContext.Request.QueryString[SearchConstants.QueryString.SearchTextName]
            });

            return View(result);
        }

    }
}