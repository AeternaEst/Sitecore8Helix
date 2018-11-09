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
    public class VideoFrame : BaseMediaFrame
    {
        public string VideoSource { get; set; }

        public bool StartAutomatically { get; set; }

        public int DelayStartBy { get; set; }

        public string ThumbnailSource { get; set; }

        /// <summary>
        /// Oldschool data mapping without page editor support
        /// </summary>
        /// <param name="dataSourceItem">The current DataSource</param>
        /// <returns></returns>
        public new bool Init(Item dataSourceItem)
        {
            if (dataSourceItem == null)
                return false;

            var ff = (FileField)dataSourceItem.Fields[Templates.VideoSource.Fields.VideoSrcId];

            if (ff?.MediaItem == null)
                return false;

            base.Init(dataSourceItem);
            VideoSource = MediaManager.GetMediaUrl(ff.MediaItem, MediaConstants.GetMediaUrlOptions);   
            StartAutomatically = dataSourceItem[Templates.VideoOptions.Fields.PlayAutomaticallyId] == "1";

            var delayStartByValue = dataSourceItem[Templates.VideoOptions.Fields.DelayStartById];
            int delayStartBy;
            if (int.TryParse(delayStartByValue, out delayStartBy))
            {
                DelayStartBy = delayStartBy;
            }

            var imf = (ImageField) dataSourceItem.Fields[Templates.VideoOptions.Fields.ThumbnailId];

            if (imf?.MediaItem != null)
            {
                ThumbnailSource = MediaManager.GetMediaUrl(imf.MediaItem, MediaConstants.GetMediaUrlOptions);
            }

            return true;
        }
    }
}