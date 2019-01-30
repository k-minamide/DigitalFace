using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Digitalface.Utilities.Extentions.RegexMatches;
using Digitalface.Utilities.Extentions.ThrowArgumentNullException4Null;

namespace Digitalface.Utilities.Extentions.Split
{
    public static class StringExtention
    {
        public static IEnumerable<string> RegexSplit(this string input, string pattern, RegexOptions options = RegexOptions.IgnoreCase)
        {
            input.ThrowArgumentNullException4Null(nameof(input));
            pattern.ThrowArgumentNullException4Null(nameof(pattern));
            options.ThrowArgumentNullException4Null(nameof(options));

            var matches = input.RegexMatches(pattern, options);

            var split = new string[matches.Count + 1];

            Match match;
            var startIndex = 0;
            var matchesCount = matches.Count;
            for (int i = 0; i < matchesCount; i++)
            {
                match = matches[i];
                split[i] = input.Substring(startIndex, match.Index - startIndex);
                startIndex = match.Index + match.Length;
            }
            split[matchesCount + 1] = input.Substring(startIndex, input.Length - startIndex);

            return split;
        }
    }
}
