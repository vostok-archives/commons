using System;

namespace Vostok.Commons.Parsers
{
    public class DataSizeParser
    {
        private delegate DataSize FromDouble(double value);
        private delegate DataSize FromLong(long value);

        public static bool TryParse(string input, out DataSize result)
        {
            input = input.ToLower();

            double Parse(string unit) => DoubleParser.Parse(PrepareInput(input, unit));
            long ParseLong(string unit) => long.Parse(PrepareInput(input, unit));

            bool TryGet(FromDouble method, string unit, out DataSize res)
            {
                res = default(DataSize);
                if (!input.Contains(unit)) return false;
                res = method(Parse(unit));
                return true;
            }
            bool TryGetL(FromLong method, string unit, out DataSize res)
            {
                res = default(DataSize);
                if (!input.Contains(unit)) return false;
                res = method(ParseLong(unit));
                return true;
            }

            if (TryGet(DataSize.FromPetabytes, Petabytes2, out result)
                || TryGet(DataSize.FromTerabytes, Terabytes2, out result)
                || TryGet(DataSize.FromGigabytes, Gigabytes2, out result)
                || TryGet(DataSize.FromMegabytes, Megabytes2, out result)
                || TryGet(DataSize.FromKilobytes, Kilobytes2, out result)
                || TryGetL(DataSize.FromBytes, Bytes2, out result)
                || TryGet(DataSize.FromPetabytes, Petabytes1, out result)
                || TryGet(DataSize.FromTerabytes, Terabytes1, out result)
                || TryGet(DataSize.FromGigabytes, Gigabytes1, out result)
                || TryGet(DataSize.FromMegabytes, Megabytes1, out result)
                || TryGet(DataSize.FromKilobytes, Kilobytes1, out result)
                || TryGetL(DataSize.FromBytes, Bytes1, out result))
                return true;

            if (long.TryParse(input, out var bytes))
            {
                result = DataSize.FromBytes(bytes);
                return true;
            }

            return false;
        }

        public static DataSize Parse(string input)
        {
            if (TryParse(input, out var res))
                return res;
            throw new FormatException($"{nameof(DataSizeParser)}. Failed to parse DataSize from string '{input}'.");
        }

        private static string PrepareInput(string input, string unit) => 
            input.Replace(unit, string.Empty).Trim('.').Trim();

        private const string Bytes1 = "b";
        private const string Bytes2 = "bytes";

        private const string Kilobytes1 = "kb";
        private const string Kilobytes2 = "kilobytes";

        private const string Megabytes1 = "mb";
        private const string Megabytes2 = "megabytes";

        private const string Gigabytes1 = "gb";
        private const string Gigabytes2 = "gigabytes";

        private const string Terabytes1 = "tb";
        private const string Terabytes2 = "terabytes";

        private const string Petabytes1 = "pb";
        private const string Petabytes2 = "petabytes";
    }
}