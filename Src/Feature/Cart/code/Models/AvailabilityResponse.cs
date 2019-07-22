using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Sitecore8Helix.Feature.Cart.Models
{
    public class AvailabilityResponse
    {
        [JsonProperty("available")]
        public bool Available { get; set; }
    }
}