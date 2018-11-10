using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Data.Fields;
using Sitecore.Mvc.Presentation;
using Sitecore8Helix.Feature.Media.Models;

namespace Sitecore8Helix.Feature.Media.Controllers
{
    public class MediaContentController : Controller
    {

        public ActionResult MediaFrame()
        {
            var dataSourceItem = Sitecore.Context.Database.GetItem(RenderingContext.Current.Rendering.DataSource);

            if (dataSourceItem != null)
            {
                if (dataSourceItem.Template.BaseTemplates.Any(template => template.ID == Templates.ImageSource.Id))
                {
                    return View("~/Views/Media/ImageFrameSc.cshtml", dataSourceItem);
                    //var imageFrameModel = new ImageFrame();
                    //imageFrameModel.Init(dataSourceItem);
                    //return View("~/Views/Media/ImageFrame.cshtml", imageFrameModel);
                }

                return View("~/Views/Media/VideoFrameSc.cshtml", dataSourceItem);
                //var videoFrameModel = new VideoFrame();
                //videoFrameModel.Init(dataSourceItem);
                //return View("~/Views/Media/VideoFrame.cshtml", videoFrameModel);
            }

            return new EmptyResult();
        }
    }
}