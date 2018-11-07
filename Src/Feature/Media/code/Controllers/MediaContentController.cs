using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sitecore8Helix.Feature.Media.Controllers
{
    public class MediaContentController : Controller
    {

        public ActionResult MediaFrame()
        {
            return View("~/Views/Media/MediaFrame.cshtml");
        }
    }
}