using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data.Items;
using Sitecore8Helix.Feature.Media.Constants;

namespace Sitecore8Helix.Feature.Media.Models
{
    [SitecoreType(TemplateId = Templates.MediaFrameText.Id)]
    public abstract class BaseMediaFrame
    {
        [SitecoreId]
        public Guid Id { get; set; }

        [SitecoreField(FieldId = Templates.MediaFrameText.Fields.TitleId)]
        public string Title { get; set; }

        [SitecoreField(FieldId = Templates.MediaFrameText.Fields.ManchetId)]
        public string Manchet { get; set; }

        public void Init(Item dataSourceItem)
        {
            Title = dataSourceItem[Templates.MediaFrameText.Fields.TitleId];
            Manchet = dataSourceItem[Templates.MediaFrameText.Fields.ManchetId];
        }
    }
}