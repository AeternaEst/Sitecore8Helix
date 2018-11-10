using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Mvc.Extensions;
using Sitecore.Resources.Media;
using Sitecore8Helix.Feature.Media.Constants;

namespace Sitecore8Helix.Feature.Media.Models
{
    [SitecoreType(TemplateId = Templates.ImageSource.Id)]
    public class ImageFrame : BaseMediaFrame
    {
        [SitecoreId]
        public Guid ImageFrameId { get; set; }

        [SitecoreField(FieldId = Templates.ImageSource.Fields.ImageSrcId)]
        public Image Image { get; set; }

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