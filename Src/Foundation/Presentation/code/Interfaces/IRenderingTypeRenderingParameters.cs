using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore8Helix.Foundation.Presentation.Models;

namespace Sitecore8Helix.Foundation.Presentation.Interfaces
{
    [SitecoreType(TemplateId = Templates.ParametersTemplateRenderingType.Id)]
    public interface IRenderingTypeRenderingParameters
    {
        [SitecoreId]
        Guid Id { get; set; }

        [SitecoreField(FieldId = Templates.ParametersTemplateRenderingType.Fields.RenderingTypeId)]
        RenderingType RenderingType { get; set; }
    }
}
