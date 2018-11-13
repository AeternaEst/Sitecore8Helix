using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data.Items;
using Sitecore.Pipelines.GetAboutInformation;
using Sitecore8Helix.Foundation.Presentation.Models;

namespace Sitecore8Helix.Foundation.Presentation.Interfaces
{
    public interface IPresentationService
    {
        object GetInitializedModel<T1, T2>(string renderingType, Item dataSourceItem, Func<T1> fetchClassic,
            Func<T1> fetchGlass, T2 renderingParams);

        string GetRenderingType(IRenderingTypeRenderingParameters renderingTypeRenderingParams);

        string GetSimpleGridCssClass(string selection);

        RenderingSettings RenderingSettings { get; }
    }
}
