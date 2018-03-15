using System;

namespace Vostok.Commons.Parsers
{
    public class FloatParser
    {
        public static bool TryParse(string input, out float res)
        {
            input = StringMethods.PrepareForFloatNumbers(input);
            return float.TryParse(input, out res);
        }
        public static float Parse(string input)
        {
            if (TryParse(input, out var res))
                return res;
            throw new FormatException($"{nameof(FloatParser)}. Error in parsing string {input} to float.");
        }
    }
}