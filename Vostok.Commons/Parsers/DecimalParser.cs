using System;

namespace Vostok.Commons.Parsers
{
    public class DecimalParser
    {
        public static bool TryParse(string input, out decimal res)
        {
            input = StringMethods.PrepareForFloatNumbers(input);
            return decimal.TryParse(input, out res);
        }
        public static decimal Parse(string input)
        {
            if (TryParse(input, out var res))
                return res;
            throw new FormatException($"{nameof(DecimalParser)}. Error in parsing string {input} to decimal.");
        }
    }
}