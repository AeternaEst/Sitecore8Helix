using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;
using Sitecore8Helix.Feature.Media.Constants;

namespace Sitecore8Helix.Feature.Media.Models
{
    public abstract class BaseMediaFrame
    {
        public string Title { get; set; }

        public string Manchet { get; set; }

        public void Init(Item dataSourceItem)
        {
            Title = dataSourceItem[Templates.MediaFrameText.Fields.TitleId];
            Manchet = dataSourceItem[Templates.MediaFrameText.Fields.ManchetId];
        }
    }
}