using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Glass.Mapper.Sc.Web.Mvc;
using Sitecore8Helix.Feature.Media.Models;
using Sitecore8Helix.Foundation.Presentation.Extensions;
using Sitecore8Helix.Foundation.Presentation.Interfaces;
using Sitecore8Helix.Foundation.Presentation.Models;
using Sitecore8Helix.Foundation.Presentation.Services;

namespace Sitecore8Helix.Feature.Media.Controllers
{
    public class MediaContentController : GlassController
    {
        protected IPresentationService PresentationService;

        public MediaContentController(IPresentationService presentationService)
        {
            PresentationService = presentationService;
        }

        public ActionResult MediaFrame()
        {
            if (DataSourceItem != null)
            {
                var renderingParams = GetRenderingParameters<IPresentationRenderingParameters>().
                    EnsureNotNull<IPresentationRenderingParameters, SimpleGridSize>("GridSize");
                var renderingType = PresentationService.GetRenderingType(renderingParams);

                if (DataSourceItem.Template.BaseTemplates.Any(template => template.ID.ToString() == Templates.ImageSource.Id))
                {
                    var imgPresentationModel = PresentationService.GetInitializedModel<ImageFrame, IPresentationRenderingParameters>(
                        renderingType, DataSourceItem, () => ImageFrame.GetImageFrame(DataSourceItem), () => GetDataSourceItem<ImageFrame>(), renderingParams);

                    return View($"~/Views/Media/ImageFrame{renderingType}.cshtml", imgPresentationModel);
                }

                var videoPresentationModel = PresentationService.GetInitializedModel<VideoFrame, IPresentationRenderingParameters>(
                    renderingType, DataSourceItem, () => VideoFrame.GetVideoFrame(DataSourceItem), () => GetDataSourceItem<VideoFrame>(), renderingParams);

                return View($"~/Views/Media/VideoFrame{renderingType}.cshtml", videoPresentationModel);
            }

            return new EmptyResult();
        }
    }
}