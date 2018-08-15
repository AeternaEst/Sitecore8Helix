using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;

namespace Sitecore8Helix.Website.Models
{
    [DataContract]
    public class ProductSearchResultItem : SearchResultItem
    {
        [IndexField("product_title_t")]
        [DataMember]
        public virtual IEnumerable<string> Title { get; set; }

        [IndexField("product_description_t")]
        [DataMember]
        public virtual IEnumerable<string> Description { get; set; }

        [IndexField("product_price_td")]
        [DataMember]
        public virtual double Price { get; set; }

        [IndexField("product_category_s")]
        [DataMember]
        public virtual string Category { get; set; }

        [IndexField("product_rating_tl")]
        [DataMember]
        public virtual int Rating { get; set; }

        [IndexField("product_type_s")]
        [DataMember]
        public virtual string Type { get; set; }

        [IndexField("product_intro_tdt")]
        [DataMember]
        public virtual DateTime IntroDate { get; set; }
    }
}