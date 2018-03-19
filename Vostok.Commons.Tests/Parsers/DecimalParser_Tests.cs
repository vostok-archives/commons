using System;
using FluentAssertions;
using NUnit.Framework;
using Vostok.Commons.Parsers;

namespace Vostok.Commons.Tests.Parsers
{
    [TestFixture]
    public class DecimalParser_Tests
    {
//        [TestCase("1.23", true, 1.23)]
//        [TestCase("1,23", true, 1.23)]
//        [TestCase("abc", false, 0)]
        [Test]
        public void Should_TryParse(/*string input, bool boolRes, decimal res*/)
        {
            decimal res;
            DecimalParser.TryParse("1.23", out res).Should().BeTrue().And.Be(res == 1.23m);
            DecimalParser.TryParse("1,23", out res).Should().BeTrue().And.Be(res == 1.23m);
            DecimalParser.TryParse("abc", out _).Should().BeFalse();
        }

        [Test]
        public void Should_throw_FormatException_on_Parse_wrong_format()
        {
            new Action(() => DecimalParser.Parse(@"cba")).Should().Throw<FormatException>();
        }
    }
}