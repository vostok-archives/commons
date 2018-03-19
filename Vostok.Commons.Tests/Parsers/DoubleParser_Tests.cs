using System;
using FluentAssertions;
using NUnit.Framework;
using Vostok.Commons.Parsers;

namespace Vostok.Commons.Tests.Parsers
{
    [TestFixture]
    public class DoubleParser_Tests
    {
        [TestCase("1.23", true, 1.23d)]
        [TestCase("1,23", true, 1.23d)]
        [TestCase("abc", false, 0d)]
        public void Should_TryParse(string input, bool boolRes, double val)
        {
            DoubleParser.TryParse(input, out var res).Should().Be(boolRes && res == val);
        }

        [Test]
        public void Should_throw_FormatException_on_Parse_wrong_format()
        {
            new Action(() => DoubleParser.Parse(@"cba")).Should().Throw<FormatException>();
        }
    }
}