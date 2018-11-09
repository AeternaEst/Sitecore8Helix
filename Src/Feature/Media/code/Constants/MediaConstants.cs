using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Resources.Media;

namespace Sitecore8Helix.Feature.Media.Constants
{
    public static class MediaConstants
    {
        private static MediaUrlOptions _mediaUrlOptions;

        public static MediaUrlOptions GetMediaUrlOptions =>
            _mediaUrlOptions ?? (_mediaUrlOptions = new MediaUrlOptions
            {
                AbsolutePath = true,
                IncludeExtension = true,
                AlwaysIncludeServerUrl = true
            });
    }
}