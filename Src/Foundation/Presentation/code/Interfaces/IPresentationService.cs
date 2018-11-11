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
        object GetInitializedModel(string renderingType, Item dataSourceItem, Func<object> fetchClassic, Func<object> fetchGlass);

        string GetRenderingType(RenderingTypeRenderingParameters renderingTypeParameters);

        RenderingSettings RenderingSettings { get; }
    }
}
