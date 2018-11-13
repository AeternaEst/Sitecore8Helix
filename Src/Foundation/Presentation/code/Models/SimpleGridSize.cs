using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace Sitecore8Helix.Foundation.Presentation.Models
{
    [SitecoreType(TemplateId = Templates.SimpleGridSize.Id)]
    public class SimpleGridSize
    {
        [SitecoreId]
        public virtual Guid Id { get; set; }

        [SitecoreField(FieldId = Templates.SimpleGridSize.Fields.SizeId)]
        public virtual string Size { get; set; }
    }
}