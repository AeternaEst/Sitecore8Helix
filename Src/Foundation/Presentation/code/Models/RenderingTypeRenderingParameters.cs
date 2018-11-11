using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace Sitecore8Helix.Foundation.Presentation.Models
{
    [SitecoreType(TemplateId = Templates.ParametersTemplateRenderingType.Id)]
    public class RenderingTypeRenderingParameters
    {
        [SitecoreId]
        public Guid Id { get; set; }

        [SitecoreField(FieldId = Templates.ParametersTemplateRenderingType.Fields.RenderingTypeId)]
        public RenderingType RenderingType { get; set; }
    }
}