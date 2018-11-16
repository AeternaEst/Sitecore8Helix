using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Sitecore.Diagnostics;
using Sitecore8Helix.Foundation.Extensions.Exceptions;

namespace Sitecore8Helix.Foundation.Extensions.FrameworkExtensions
{
    public static class GenericExtensions
    {
        public static T1 EnsureNotNull<T1, T2>(this T1 parent, string propName)
        {
            return EnsureNotNullInner<T1, T2>(parent, propName);
        }

        public static T1 EnsureNotNull<T1, T2>(this T1 parent, Func<T1, string> info)
        {
            return EnsureNotNullInner<T1, T2>(parent, info.Invoke(parent));
        }

        private static T1 EnsureNotNullInner<T1, T2>(T1 parent, string propName)
        {
            Assert.IsNotNull(parent, nameof(parent));
            Assert.IsNotNullOrEmpty(propName, nameof(propName));

            var parentType = parent.GetType();
            var prop = parentType.GetProperty(propName);

            if (prop != null)
            {
                var value = prop.GetValue(parent, null);
                if (value == null)
                {
                    var qt = Activator.CreateInstance<T2>();
                    prop.SetValue(parent, qt);
                }

                return parent;
            }

            throw new PropertyNotFoundException($"{Constants.ExceptionMessages.PropertyNotFoundMessage} {parentType}");
        }
    }
}