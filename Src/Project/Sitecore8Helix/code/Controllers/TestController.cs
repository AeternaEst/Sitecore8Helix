using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq;
using Sitecore.ContentSearch.Utilities;
using Sitecore8Helix.Website.Models;

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

            var index = ContentSearchManager.GetIndex("sitecore_master_index");
            List<Store> stores = new List<Store>();
            using (var searchContext = index.CreateSearchContext())
            {
                var query = searchContext.GetQueryable<StoreSearchResultItem>().
                    Where(item => item.TemplateName == "Store");

                var results = query.GetResults();
                foreach (var result in results.Hits)
                {
                    stores.Add(new Store
                    {
                        Name = result.Document.StoreName.FirstOrDefault(),
                        Description = result.Document.Description.FirstOrDefault(),
                        City = result.Document.City,
                        Country = result.Document.Country,
                        Street = result.Document.Street,
                        StreetNumber = result.Document.StreetNumber,
                        Type = result.Document.Type,
                        ZipCode = result.Document.ZipCode
                    });
                }
            }

            return View(stores);
        }
    }
}