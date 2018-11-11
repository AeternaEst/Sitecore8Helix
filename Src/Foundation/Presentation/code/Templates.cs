using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore8Helix.Foundation.Presentation
{
    public static class Templates
    {
        public static class RenderingSettings
        {
            public const string Id = "{14197FFF-2867-4E5E-A12A-320BEAD9EDE3}";

            public static class Fields
            {
                public const string DefaultRenderingTypeId = "{0666CF36-F023-4090-A995-DE85AF2BC18F}";

                public const string AlwaysUseDefaultRenderingId = "{BC1BCBAA-E3D1-48C7-BE65-5341C630684A}";
            }
        }

        public static class RenderingType
        {
            public const string Id = "{4E2DC2E5-59D3-40A2-B5DF-713D0425330D}";

            public static class Fields
            {
                public const string TypeId = "{E4C00F91-163E-46E3-8CAB-D6684864787B}";
            }
        }

        public static class ParametersTemplateRenderingType
        {
            public const string Id = "{4BE917AF-F7BF-4A73-963E-A65B0AE57E84}";

            public static class Fields
            {
                public const string RenderingTypeId = "{8E2FED42-1AA2-4D9E-B72B-3975A889EBBC}";
            }
        }
    }
}