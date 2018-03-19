using System;
using FluentAssertions;
using NUnit.Framework;
using Vostok.Commons.Parsers;

namespace Vostok.Commons.Tests.Parsers
{
    [TestFixture]
    public class FloatParser_Tests
    {
        [TestCase("1.23", true, 1.23f)]
        [TestCase("1,23", true, 1.23f)]
        [TestCase("abc", false, 0f)]
        public void Should_TryParse(string input, bool boolRes, float val)
        {
            FloatParser.TryParse(input, out var res).Should().Be(boolRes && res == val);
        }

        [Test]
        public void Should_throw_FormatException_on_Parse_wrong_format()
        {
            new Action(() => FloatParser.Parse(@"cba")).Should().Throw<FormatException>();
        }
    }
}