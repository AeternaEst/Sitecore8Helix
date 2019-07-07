using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Sitecore8Helix.Foundation.Search.Models;

namespace Sitecore8Helix.Feature.Cart.Models
{
    public class Cart
    {
        [JsonProperty("products")]
        public IEnumerable<CartProduct> Products { get; set; }

        [JsonProperty("cartId")]
        public string CartId { get; set; }
    }
}