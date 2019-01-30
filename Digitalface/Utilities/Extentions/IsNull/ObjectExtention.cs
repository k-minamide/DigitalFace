using System;

namespace Digitalface.Utilities.Extentions.IsNull
{
    public static class ObjectExtention
    {
        public static bool IsNull(this object value)
        {
            return value == null;
        }
    }
}
