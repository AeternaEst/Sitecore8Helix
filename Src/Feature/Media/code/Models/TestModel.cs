using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace Sitecore8Helix.Feature.Media.Models
{
    [SitecoreType(TemplateId = "{3DA5A828-FE3D-4E1F-ACF3-C6F0B9544D82}", AutoMap = true)]
    public class TestModel
    {
        public virtual Guid Id { get; set; }

        public virtual string Test { get; set; }
    }
}