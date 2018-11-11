using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace Sitecore8Helix.Foundation.Presentation.Models
{
    [SitecoreType(TemplateId = Templates.RenderingType.Id)]
    public class RenderingType
    {
        [SitecoreId]
        public virtual Guid Id { get; set; }

        [SitecoreField(FieldId = Templates.RenderingType.Fields.TypeId)]
        public virtual string Type { get; set; }
    }
}