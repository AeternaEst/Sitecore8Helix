using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Sitecore8Helix.Foundation.Search.Models;

namespace Sitecore8Helix.Feature.Cart.Models
{
    public class CartProduct
    {
        [JsonProperty("product")]
        public Product Product { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }
    }
}