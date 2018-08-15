using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore8Helix.Website.Models
{
    public class Product
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public string Category { get; set; }

        public int Rating { get; set; }

        public string Type { get; set; }

        public DateTime IntroDate { get; set; }
    }
}