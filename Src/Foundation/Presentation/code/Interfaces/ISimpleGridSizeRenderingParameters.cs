using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore8Helix.Foundation.Presentation.Models;

namespace Sitecore8Helix.Foundation.Presentation.Interfaces
{
    [SitecoreType(TemplateId = Templates.ParametersTemplateSimpleGridSize.Id)]
    public interface ISimpleGridSizeRenderingParameters
    {
        [SitecoreId]
        Guid Id { get; set; }

        [SitecoreField(FieldId = Templates.ParametersTemplateSimpleGridSize.Fields.SizeId)]
        SimpleGridSize GridSize { get; set; }
    }
}
