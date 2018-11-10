using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace Sitecore8Helix.Feature.Media
{
    public static class Templates
    {
        public static class MediaFrameText
        {
            public static ID Id => new ID("{78ABE6D0-8236-4961-A9C3-79F12E381727}");

            public static class Fields
            {
                public static ID TitleId => new ID("{033858D2-B906-4A48-B3F9-9C045421D582}");
                public static ID ManchetId => new ID("{C1911A77-A4D2-4233-866E-8BC598266EA4}");
            } 
        }

        public static class ImageSource
        {
            public static ID Id => new ID("{8B86E194-89A9-4065-A2C4-67E22A3202BA}");

            public static class Fields
            {
                public static ID ImageSrcId => new ID("{E66F6BFA-D635-4749-BB46-6C01DB7CCF86}");
            }
        }

        public static class VideoSource
        {
            public static ID Id => new ID("{59BDF204-C1CD-4B26-B238-F8BE6EEF1579}");

            public static class Fields
            {
                public static ID VideoSrcId => new ID("{0ABE551D-68C0-4CD8-8616-9637A2573AF1}");
            }            
        }

        public static class VideoOptions
        {
            public static ID Id => new ID("{9F4485A2-0326-48AD-B44B-DCEAFBEADAE0}");

            public static class Fields
            {
                public static ID PlayAutomaticallyId => new ID("{4B79AC81-0A42-4E92-B3F1-951B0AE32736}");
                public static ID DelayStartById => new ID("{A79C5544-3DD1-4DAE-800F-1E88BFC02154}");
                public static ID ThumbnailId => new ID("{421D0A5B-3419-486E-B66C-B12EF9335B67}");
            }
        }
    }
}