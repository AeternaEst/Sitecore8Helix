using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using SolrNet.Attributes;

namespace Sitecore8Helix.Foundation.Search.Models
{
    [DataContract]
    public class ProductSearchResultItem : SearchResultItem
    {
        [SolrField("pid_s")]
        [IndexField("pid_s")]
        [DataMember]
        public virtual string ProductId { get; set; }

        [SolrField("product_title_t")]
        [IndexField("product_title_t")]
        [DataMember]
        public virtual IEnumerable<string> Title { get; set; }

        [SolrField("product_description_t")]
        [IndexField("product_description_t")]
        [DataMember]
        public virtual IEnumerable<string> Description { get; set; }

        [SolrField("product_price_td")]
        [IndexField("product_price_td")]
        [DataMember]
        public virtual double Price { get; set; }

        [SolrField("product_category_s")]
        [IndexField("product_category_s")]
        [DataMember]
        public virtual string Category { get; set; }

        [SolrField("product_rating_tl")]
        [IndexField("product_rating_tl")]
        [DataMember]
        public virtual int Rating { get; set; }

        [SolrField("product_type_s")]
        [IndexField("product_type_s")]
        [DataMember]
        public virtual string Type { get; set; }

        [SolrField("product_intro_tdt")]
        [IndexField("product_intro_tdt")]
        [DataMember]
        public virtual DateTime IntroDate { get; set; }
    }
}