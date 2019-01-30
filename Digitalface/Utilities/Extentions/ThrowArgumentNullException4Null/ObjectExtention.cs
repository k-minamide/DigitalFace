using System;
using Digitalface.Utilities.Extentions.IsNull;

namespace Digitalface.Utilities.Extentions.ThrowArgumentNullException4Null
{
    public static class ObjectExtention
    {
        public static void ThrowArgumentNullException4Null(this object value)
        {
            if (value.IsNull()) throw new ArgumentNullException();
        }

        public static void ThrowArgumentNullException4Null(this object value, string paramName)
        {
            if (value.IsNull()) throw new ArgumentNullException(paramName);
        }
    }
}
