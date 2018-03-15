﻿using System;

namespace Vostok.Commons.Parsers
{
    public class UriParser
    {
        public static bool TryParse(string input, out Uri result)
        {
            return Uri.TryCreate(input, UriKind.RelativeOrAbsolute, out result);
        }

        public static Uri Parse(string input)
        {
            if (TryParse(input, out var res))
                return res;
            throw new FormatException($"{nameof(UriParser)}. Failed to parse TimeSpan from string '{input}'.");
        }
    }
}