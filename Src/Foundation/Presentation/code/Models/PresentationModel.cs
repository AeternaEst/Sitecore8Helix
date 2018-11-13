using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore8Helix.Foundation.Presentation.Models
{
    public class PresentationModel<T1, T2>
    {
        public T1 Data { get; set; }

        public T2 RenderingParams { get; set; }
    }
}