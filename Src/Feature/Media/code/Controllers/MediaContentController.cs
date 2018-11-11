using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Glass.Mapper.Sc.Web.Mvc;
using Sitecore8Helix.Feature.Media.Models;
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
                var renderingType = PresentationService.GetRenderingType(GetRenderingParameters<RenderingTypeRenderingParameters>());

                if (DataSourceItem.Template.BaseTemplates.Any(template => template.ID.ToString() == Templates.ImageSource.Id))
                {
                    var imageFrameModel = PresentationService.GetInitializedModel(renderingType, DataSourceItem,
                        () => ImageFrame.GetImageFrame(DataSourceItem), () => GetDataSourceItem<ImageFrame>());

                    return View($"~/Views/Media/ImageFrame{renderingType}.cshtml", imageFrameModel);
                }

                var videoFrameModel = PresentationService.GetInitializedModel(renderingType, DataSourceItem,
                    () => VideoFrame.GetVideoFrame(DataSourceItem), () => GetDataSourceItem<VideoFrame>());

                return View($"~/Views/Media/VideoFrame{renderingType}.cshtml", videoFrameModel);
            }

            return new EmptyResult();
        }
    }
}