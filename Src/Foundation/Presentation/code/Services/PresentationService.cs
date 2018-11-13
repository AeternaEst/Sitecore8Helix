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

        public string GetRenderingType(IRenderingTypeRenderingParameters renderingTypeRenderingParams)
        {
            Assert.IsNotNull(RenderingSettings, nameof(RenderingSettings));

            if (!RenderingSettings.AlwaysUseDefaultRendering && !string.IsNullOrEmpty(renderingTypeRenderingParams?.RenderingType?.Type))
            {
                return renderingTypeRenderingParams.RenderingType.Type;
            }

            return RenderingSettings.DefaultRenderingType.Type;
        }

        public object GetInitializedModel<T1, T2>(string renderingType, Item dataSourceItem, Func<T1> fetchClassic,
            Func<T1> fetchGlass, T2 renderingParams)
        {
            switch (renderingType)
            {
                case "Classic":
                    var presentationModel = new PresentationModel<T1, T2>();
                    presentationModel.Data = fetchClassic();
                    presentationModel.RenderingParams = renderingParams;
                    return presentationModel; 
                case "Sitecore":
                    var presentationModell = new PresentationModel<Item, T2>();
                    presentationModell.Data = dataSourceItem;
                    presentationModell.RenderingParams = renderingParams;
                    return presentationModell;
                default:
                    var presentationModelll = new PresentationModel<T1, T2>();
                    presentationModelll.Data = fetchGlass();
                    presentationModelll.RenderingParams = renderingParams;
                    return presentationModelll;
            }
        }

        public string GetSimpleGridCssClass(string selection)
        {
            switch (selection)
            {
                case "25":
                    return "col-md-3";
                case "50":
                    return "col-md-6";
                case "75":
                    return "col-md-9";
                case "100":
                    return "col-md-12";
            }

            return default(string);
        }
    }
}