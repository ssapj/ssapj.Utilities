using BarTender;
using System.Collections.Generic;
using static ssapj.Utilities.Converter;
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

        public static (byte a, byte r, byte g, byte b) ToArgbByteValueTuple(this uint value)
        {
	        return GetArgbByteValueTuple(value);
        }

	}
}
