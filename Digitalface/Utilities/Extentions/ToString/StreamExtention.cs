using System;
using System.Text;
using Digitalface.Utilities.Extentions.ThrowArgumentNullException4Null;

namespace Digitalface.Utilities.Extentions.Stream.ToString
{
    public static class Extention
    {
        public static string ToString(this System.IO.Stream stream, Encoding encoding = Encoding.UTF8)
        {
            // 引数確認
            stream.ThrowArgumentNullException4Null(nameof(stream));
            encoding.ThrowArgumentNullException4Null(nameof(encoding));

            stream.Position = 0;
            byte[] buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);

            return encoding.GetString(buffer);
        }
    }
}
