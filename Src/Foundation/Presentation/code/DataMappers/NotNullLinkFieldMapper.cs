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
    public class NotNullLinkFieldMapper : SitecoreFieldLinkMapper
    {
        public override object GetField(Field field, SitecoreFieldConfiguration config, SitecoreDataMappingContext context)
        {
            var value = base.GetField(field, config, context);

            if (value == null)
            {
                value = new Link();
            }

            return value;
        }
    }
}