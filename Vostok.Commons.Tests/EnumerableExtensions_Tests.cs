using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Vostok.Commons.Tests
{
    [TestFixture]
    public class EnumerableExtensions_Tests
    {
        [Test]
        public void Should_extend_ToEnumerable()
        {
            var val = 1;
            val.ToEnumerable().ToArray().Should().BeEquivalentTo(new[] {1});
        }
    }
}