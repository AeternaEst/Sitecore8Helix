using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore8Helix.Feature.Cart.Models
{
    public class AddProductRequest
    {
        public string ProductId { get; set; }

        public int Quantity { get; set; }
    }
}