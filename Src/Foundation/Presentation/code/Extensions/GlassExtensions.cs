using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore8Helix.Foundation.Presentation.Extensions
{
    public static class GlassExtensions
    {
        public static T1 EnsureNotNull<T1, T2>(this T1 t, string propName)
        {
            //objName.GetType().GetProperty("nameOfProperty").SetValue(objName, objValue, null)
            var type = t.GetType();
            
            var prop = type.GetProperty(propName);

            if (prop != null)
            {
                var value = prop.GetValue(t, null);
                if (value == null)
                {
                    var qt = Activator.CreateInstance<T2>();
                    prop.SetValue(t, qt);
                }

                return t;
            }

            throw new Exception("Fuck");
        }
    }
}