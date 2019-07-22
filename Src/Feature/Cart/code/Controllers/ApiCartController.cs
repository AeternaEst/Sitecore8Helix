using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;
using Sitecore.Diagnostics;
using Sitecore8Helix.Feature.Cart.Models;
using Sitecore8Helix.Foundation.Search.Constants;
using Sitecore8Helix.Foundation.Search.Handles;
using Sitecore8Helix.Foundation.Search.Models;

namespace Sitecore8Helix.Feature.Cart.Controllers
{
    public class ApiCartController : ApiController
    {
        protected static List<CartProduct> ProductsInCart = new List<CartProduct>();
        protected SearchSolrNetProductsHandle SolrNetProductsHandle;

        public ApiCartController(SearchSolrNetProductsHandle solrNetProductsHandle)
        {
            SolrNetProductsHandle = solrNetProductsHandle;
        }

        public IHttpActionResult CheckProductAvailability(AvailabilityRequest request)
        {
            Assert.ArgumentNotNullOrEmpty(request.ProductId, nameof(request.ProductId));
            Thread.Sleep(500);
            var random = new Random();
            var number = random.Next(10);
            return Json(new AvailabilityResponse { Available = number <= 5});
        }

        public IHttpActionResult Get()
        {
            Thread.Sleep(1000);
            var cart = GetCart();
            return Json(cart);
        }

        [HttpPost]
        public IHttpActionResult Add(AddProductRequest request)
        {
            Thread.Sleep(1000);
            var searchQuery = new SearchQuery
            {
                Filters = new List<KeyValuePair<string, List<string>>>
                {
                    new KeyValuePair<string, List<string>>("pid_s", new List<string> {request.ProductId})
                },
                TemplateName = SearchConstants.Templates.ProductTemplateName,
                Language = Sitecore.Context.Language.ToString(),
                ContextDatabase = Sitecore.Context.Database.Name
            };
            var searchResults = SolrNetProductsHandle.Handle(searchQuery);
            var product = searchResults.Results.First(x => x.Id == request.ProductId);
            AddProduct(product, request.Quantity);

            return Json(new UpdateCartResponse
            {
                Success = true,
                Message = "Add cart success"
            });
        }

        [HttpPost]
        public IHttpActionResult Delete(DeleteProductRequest request)
        {
            Thread.Sleep(1000);
            ProductsInCart.RemoveAll(p => p.Product.Id == request.ProductId);

            return Json(new UpdateCartResponse
            {
                Success = true,
                Message = "Delete cart success"
            });
        }

        private Models.Cart GetCart()
        {
            var cart = new Models.Cart
            {
                CartId = "FakeCart",
                Products = ProductsInCart
            };

            return cart;
        }

        private void AddProduct(Product product, int quantity)
        {
            var existingProduct = ProductsInCart.FirstOrDefault(p => p.Product.Id == product.Id);
            if (existingProduct == null)
            {
                ProductsInCart.Add(new CartProduct
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                existingProduct.Quantity += quantity;
            }
        }
    }
}