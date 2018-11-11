using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Configuration.Fluent;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Resources.Media;
using Sitecore8Helix.Feature.Media.Constants;

namespace Sitecore8Helix.Feature.Media.Models
{
    [SitecoreType(TemplateId = Templates.VideoOptions.Id)]
    public class VideoFrame : BaseMediaFrame
    {
        #region Glassmapper
        [SitecoreId]
        public Guid VideoFrameId { get; set; }

        [SitecoreField(FieldId = Templates.VideoSource.Fields.VideoSrcId)]
        public File Video { get; set; }

        [SitecoreField(FieldId = Templates.VideoOptions.Fields.PlayAutomaticallyId)]
        public bool StartAutomatically { get; set; }

        [SitecoreField(FieldId = Templates.VideoOptions.Fields.DelayStartById)]
        public int DelayStartBy { get; set; }

        [SitecoreField(FieldId = Templates.VideoOptions.Fields.ThumbnailId)]
        public Image Thumbnail { get; set; }
        #endregion

        #region Manual Data Mapping
        public string ThumbnailSource { get; set; }

        public string VideoSource { get; set; }
        #endregion

        public static VideoFrame GetVideoFrame(Item dataSourceItem)
        {
            var model = new VideoFrame();
            model.Init(dataSourceItem);
            return model;
        }

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