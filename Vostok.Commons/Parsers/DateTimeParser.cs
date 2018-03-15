using System;
using System.Globalization;

namespace Vostok.Commons.Parsers
{
    public class DateTimeParser
    {
        private static CultureInfo usCulture;
        private static CultureInfo ruCulture;

        public static bool TryParse(string input, out DateTime result)
        {
            if (usCulture == null)
                usCulture = CultureInfo.GetCultureInfo("en-US");
            if (ruCulture == null)
                ruCulture = CultureInfo.GetCultureInfo("ru-RU");

            return DateTime.TryParse(input, out result)
                || DateTime.TryParse(input, CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces, out result)
                || DateTime.TryParse(input, CultureInfo.CurrentCulture, DateTimeStyles.AllowWhiteSpaces, out result)
                || DateTime.TryParse(input, ruCulture, DateTimeStyles.AllowWhiteSpaces, out result)
                || DateTime.TryParse(input, usCulture, DateTimeStyles.AllowWhiteSpaces, out result)
                || TryParseDatetime(input, ".", out result)
                || TryParseDatetime(input, "/", out result)
                || TryParseDatetime(input, "-", out result)
                || DateTime.TryParseExact(input, "yyyyMMddTHHmmsszzz", null, DateTimeStyles.AllowWhiteSpaces, out result)
                || DateTime.TryParseExact(input, "yyyyMMddTHHmmss", null, DateTimeStyles.AllowWhiteSpaces, out result)
                || DateTime.TryParseExact(input, "yyyyMMdd", null, DateTimeStyles.AllowWhiteSpaces, out result)
                || DateTime.TryParseExact(input, "HHmmss", null, DateTimeStyles.AllowWhiteSpaces, out result)
                ;
        }
        public static DateTime Parse(string input)
        {
            if (TryParse(input, out var res))
                return res;
            throw new FormatException($"{nameof(DateTimeParser)}. Failed to parse TimeSpan from string '{input}'.");
        }

        private static bool TryParseDatetime(string value, string dateSeparator, out DateTime dt)
        {
            var formatInfo = new DateTimeFormatInfo { DateSeparator = dateSeparator, TimeSeparator = ":" };
            return DateTime.TryParse(value, formatInfo, DateTimeStyles.AllowWhiteSpaces, out dt);
        }
    }
}