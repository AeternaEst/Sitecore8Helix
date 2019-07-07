using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Sitecore8Helix.Foundation.Search.Models
{
    public class Product
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("rating")]
        public int Rating { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("introDate")]
        public DateTime IntroDate { get; set; }
    }
}