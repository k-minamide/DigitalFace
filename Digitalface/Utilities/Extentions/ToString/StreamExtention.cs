using System;
using System.IO;
using System.Text;
using Digitalface.Utilities.Extentions.ThrowArgumentNullException4Null;

namespace Digitalface.Utilities.Extentions.ToString
{
    public static class Extention
    {
        public static string ToString(this Stream stream)
        {
            return stream.ToString(Encoding.UTF8);
        }

        public static string ToString(this Stream stream, Encoding encoding)
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
