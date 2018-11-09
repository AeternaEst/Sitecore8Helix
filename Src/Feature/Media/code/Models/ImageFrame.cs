using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Resources.Media;
using Sitecore8Helix.Feature.Media.Constants;

namespace Sitecore8Helix.Feature.Media.Models
{
    public class ImageFrame : BaseMediaFrame
    {
        public string ImageSource { get; set; }

        /// <summary>
        /// Oldschool data mapping without page editor support
        /// </summary>
        /// <param name="dataSourceItem">The current DataSource</param>
        /// <returns></returns>
        public new bool Init(Item dataSourceItem)
        {
            if (dataSourceItem == null)
                return false;

            var imf = (ImageField)dataSourceItem.Fields[Templates.ImageSource.Fields.ImageSrcId];

            if (imf?.MediaItem == null)
                return false;

            base.Init(dataSourceItem);
            ImageSource = MediaManager.GetMediaUrl(imf.MediaItem, MediaConstants.GetMediaUrlOptions);

            return true;
        }
    }
}