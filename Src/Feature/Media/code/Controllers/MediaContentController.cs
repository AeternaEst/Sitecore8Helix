using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Glass.Mapper.Sc.Web.Mvc;
using Sitecore.Data.Fields;
using Sitecore.Mvc.Presentation;
using Sitecore8Helix.Feature.Media.Models;

namespace Sitecore8Helix.Feature.Media.Controllers
{
    public class MediaContentController : GlassController
    {

        public ActionResult MediaFrame()
        {
            var dataSourceItem = Sitecore.Context.Database.GetItem(RenderingContext.Current.Rendering.DataSource);

            if (dataSourceItem != null)
            {
                if (dataSourceItem.Template.BaseTemplates.Any(template => template.ID.ToString() == Templates.ImageSource.Id))
                {
                    var imageFrameModel = GetDataSourceItem<ImageFrame>();

                    return View("~/Views/Media/ImageFrameGlass.cshtml", imageFrameModel);
                    //return View("~/Views/Media/ImageFrameSc.cshtml", dataSourceItem);
                    //var imageFrameModel = new ImageFrame();
                    //imageFrameModel.Init(dataSourceItem);
                    //return View("~/Views/Media/ImageFrame.cshtml", imageFrameModel);
                }

                var videoFrameModel = GetDataSourceItem<VideoFrame>();
                return View("~/Views/Media/VideoFrameGlass.cshtml", videoFrameModel);
                //return View("~/Views/Media/VideoFrameSc.cshtml", dataSourceItem);
                //var videoFrameModel = new VideoFrame();
                //videoFrameModel.Init(dataSourceItem);
                //return View("~/Views/Media/VideoFrame.cshtml", videoFrameModel);
            }

            return new EmptyResult();
        }
    }
}