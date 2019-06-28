using BarTender;
using System.Collections.Generic;
// ReSharper disable CheckNamespace

namespace ssapj.Utilities
{
    public static class SsapjExtensions
    {
        public static IEnumerable<DesignObject> ToEnumerable(this DesignObjects designObjects)
        {
            foreach (DesignObject designObject in designObjects)
            {
                yield return designObject;
            }
        }
    }
}
