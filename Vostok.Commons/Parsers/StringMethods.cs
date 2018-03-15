﻿using System.Globalization;

namespace Vostok.Commons.Parsers
{
    public class StringMethods
    {
        public static string PrepareForFloatNumbers(string input)
        {
            var sep = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
            return input.Replace(',', sep).Replace('.', sep);
        }

        public static string PrepareForTimeSpan(string input) => 
            input.ToLower().Replace(',', '.');
    }
}