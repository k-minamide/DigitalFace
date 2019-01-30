using System;
using System.Text.RegularExpressions;
using Digitalface.Utilities.Extentions.ThrowArgumentNullException4Null;

namespace Digitalface.Utilities.Extentions.RegexMatches
{
    public static class StringExtention
    {
        public static MatchCollection RegexMatches(this string input, string pattern, RegexOptions options = RegexOptions.IgnoreCase)
        {
            input.ThrowArgumentNullException4Null(nameof(input));
            pattern.ThrowArgumentNullException4Null(nameof(pattern));
            options.ThrowArgumentNullException4Null(nameof(options));

            return Regex.Matches(input, pattern, options);
        }
    }
}
