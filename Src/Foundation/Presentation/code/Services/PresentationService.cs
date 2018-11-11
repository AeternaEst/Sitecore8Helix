using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore8Helix.Foundation.Presentation.Constants;
using Sitecore8Helix.Foundation.Presentation.Extensions;
using Sitecore8Helix.Foundation.Presentation.Interfaces;
using Sitecore8Helix.Foundation.Presentation.Models;

namespace Sitecore8Helix.Foundation.Presentation.Services
{
    public class PresentationService : IPresentationService
    {
        private RenderingSettings _renderingSettings;

        public RenderingSettings RenderingSettings => _renderingSettings ??
                                                      (_renderingSettings = Sitecore.Context.Database.GetItem(new ID(
                                                      PresentationConstants.RenderingSettings.Id)).ToModel<RenderingSettings>());

        public string GetRenderingType(RenderingTypeRenderingParameters renderingTypeParameters)
        {
            Assert.IsNotNull(RenderingSettings, nameof(RenderingSettings));

            if (!RenderingSettings.AlwaysUseDefaultRendering && !string.IsNullOrEmpty(renderingTypeParameters?.RenderingType?.Type))
            {
                return renderingTypeParameters.RenderingType.Type;
            }

            return RenderingSettings.DefaultRenderingType.Type;
        }

        public object GetInitializedModel(string renderingType, Item dataSourceItem, Func<object> fetchClassic, Func<object> fetchGlass)
        {
            switch (renderingType)
            {
                case "Classic":
                    return fetchClassic();
                case "Sitecore":
                    return dataSourceItem;
                default:
                    return fetchGlass();
            }
        }
    }
}