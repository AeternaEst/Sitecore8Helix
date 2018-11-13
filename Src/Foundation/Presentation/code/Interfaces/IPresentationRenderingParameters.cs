using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace Sitecore8Helix.Foundation.Presentation.Interfaces
{
    [SitecoreType(TemplateId = Templates.ParametersTemplatePresentation.Id)]
    public interface IPresentationRenderingParameters : ISimpleGridSizeRenderingParameters, IRenderingTypeRenderingParameters
    {
        [SitecoreId]
        new Guid Id { get; set; }
    }
}
