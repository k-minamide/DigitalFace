using System;
using System.Text.RegularExpressions;
using Digitalface.Utilities.Extentions.ThrowArgumentNullException4Null;

namespace Digitalface.Utilities.Extentions.RegexMatch
{
    public static class StringExtention
    {
        public static Match RegexMatch(this string input, string pattern, RegexOptions options = RegexOptions.IgnoreCase)
        {
            input.ThrowArgumentNullException4Null(nameof(input));
            pattern.ThrowArgumentNullException4Null(nameof(pattern));
            options.ThrowArgumentNullException4Null(nameof(options));

            return Regex.Match(input, pattern, options);
        }
    }
}
