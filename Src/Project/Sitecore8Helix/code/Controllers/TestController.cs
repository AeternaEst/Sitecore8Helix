﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq;
using Sitecore.ContentSearch.Utilities;
using Sitecore8Helix.Website.Handles;
using Sitecore8Helix.Website.Models;
using Sitecore8Helix.Website.Services;

namespace Sitecore8Helix.Website.Controllers
{
    public class TestController : Controller
    {
        public ActionResult Test()
        {
            return View();
        }

        public ActionResult Stores()
        {
            var title = Sitecore.Context.Item["Headline"];
            var text = Sitecore.Context.Item["Text"];

            ViewBag.Title = title;
            ViewBag.Text = text;

            var searchService = new SearchService();
            var storesHandle = new SearchStoresHandle();

            var result = storesHandle.Handle(new SearchStoresQuery
            {
                Language = Sitecore.Context.Language.ToString(),
                TemplateName = "Store",
                ContextDatabase = Sitecore.Context.Database.Name,
                Facets = searchService.GetSelectedFacets(Sitecore.Context.Item),
                Filters = searchService.GetSelectedFilters(HttpContext.Request.QueryString),
                SearchText = HttpContext.Request.QueryString["searchText"]
            });

            return View(result);
        }

        public ActionResult Products()
        {
            return View();
        }
    }
}