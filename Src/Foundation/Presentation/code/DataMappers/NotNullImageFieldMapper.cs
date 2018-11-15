using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.DataMappers;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data.Fields;

namespace Sitecore8Helix.Foundation.Presentation.DataMappers
{
    public class NotNullImageFieldMapper : SitecoreFieldImageMapper
    {
        public override object GetField(Field field, SitecoreFieldConfiguration config, SitecoreDataMappingContext context)
        {
            var image = base.GetField(field, config, context);

            if (image == null)
            {
                image = new Image();
            }

            return image;
        }
    }
}