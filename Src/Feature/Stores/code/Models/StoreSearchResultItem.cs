using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using System.Runtime.Serialization;

namespace Sitecore8Helix.Feature.Stores.Models
{
    public class StoreSearchResultItem : SearchResultItem
    {
        [IndexField("name_t")]
        [DataMember]
        public virtual IEnumerable<string> StoreName
        {
            get;
            set;
        }

        [IndexField("description_t")]
        [DataMember]
        public virtual IEnumerable<string> Description
        {
            get;
            set;
        }

        [IndexField("country_s")]
        [DataMember]
        public virtual string Country
        {
            get;
            set;
        }

        [IndexField("city_s")]
        [DataMember]
        public virtual string City
        {
            get;
            set;
        }

        [IndexField("street_s")]
        [DataMember]
        public virtual string Street
        {
            get;
            set;
        }

        [IndexField("street_number_s")]
        [DataMember]
        public virtual string StreetNumber
        {
            get;
            set;
        }

        [IndexField("zip_code_s")]
        [DataMember]
        public virtual string ZipCode
        {
            get;
            set;
        }

        [IndexField("store_type_s")]
        [DataMember]
        public virtual string Type
        {
            get;
            set;
        }
    }
}