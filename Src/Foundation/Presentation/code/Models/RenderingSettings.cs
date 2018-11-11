using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace Sitecore8Helix.Foundation.Presentation.Models
{
    [SitecoreType(TemplateId = Templates.RenderingSettings.Id)]
    public class RenderingSettings
    {
        [SitecoreId]
        public virtual Guid Id { get; set; }

        [SitecoreField(FieldId = Templates.RenderingSettings.Fields.DefaultRenderingTypeId)]
        public virtual RenderingType DefaultRenderingType { get; set; }

        [SitecoreField(FieldId = Templates.RenderingSettings.Fields.AlwaysUseDefaultRenderingId)]
        public virtual bool AlwaysUseDefaultRendering { get; set; }

    }
}