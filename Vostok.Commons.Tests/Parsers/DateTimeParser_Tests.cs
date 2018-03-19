using System;
using FluentAssertions;
using NUnit.Framework;
using Vostok.Commons.Parsers;

namespace Vostok.Commons.Tests.Parsers
{
    [TestFixture]
    public class DateTimeParser_Tests
    {
        [TestCase("2018-03-14 15:09:26.535", true, 2018, 3, 14, 15, 9, 26, 535)]
        [TestCase("2018-03-14T15:09:26.535", true, 2018, 3, 14, 15, 9, 26, 535)]
        [TestCase("20050809T181142+0330", true, 2005, 8, 9, 18 + 3 - 1/*?*/, 11 + 30, 42, 0)]
        [TestCase("20050809T181142", true, 2005, 8, 9, 18, 11, 42, 0)]
        [TestCase("20050809", true, 2005, 8, 9, 0, 0, 0, 0)]
        [TestCase("2005/08/09", true, 2005, 8, 9, 0, 0, 0, 0)]
        [TestCase("2005.08.09", true, 2005, 8, 9, 0, 0, 0, 0)]
        [TestCase("11:22:33", true, 0, 0, 0, 11, 22, 33, 0)]
        [TestCase("11:22:33.044", true, 0, 0, 0, 11, 22, 33, 44)]
        [TestCase("112233", true, 0, 0, 0, 11, 22, 33, 0)]
        [TestCase("123", false, 0, 0, 0, 0, 0, 0, 0)]
        public void Should_TryParse(string input, bool boolRes, int y, int m, int d, int h, int min, int s, int ms)
        {
            if (y == 0 && m == 0 && d == 0)
            {
                y = DateTime.Now.Year;
                m = DateTime.Now.Month;
                d = DateTime.Now.Day;
            }
            DateTimeParser.TryParse(input, out var res).Should()
                .Be(boolRes && res == new DateTime(y, m, d, h, min, s, ms));
        }

        [Test]
        public void Should_throw_FormatException_on_Parse_wrong_format()
        {
            new Action(() => DateTimeParser.Parse(@"123")).Should().Throw<FormatException>();
        }
    }
}