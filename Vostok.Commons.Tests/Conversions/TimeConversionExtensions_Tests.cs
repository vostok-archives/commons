using System;
using FluentAssertions;
using NUnit.Framework;
using Vostok.Commons.Conversions;

namespace Vostok.Commons.Tests.Conversions
{
    [TestFixture]
    public class TimeConversionExtensions_Tests
    {
        [Test]
        public void Should_turn_int_into_Ticks()
        {
            int val = 123;
            val.Ticks().Should().Be(TimeSpan.FromTicks(val));
        }

        [Test]
        public void Should_turn_long_into_Ticks()
        {
            long val = 123;
            val.Ticks().Should().Be(TimeSpan.FromTicks(val));
        }

        [Test]
        public void Should_turn_ushort_into_Milliseconds()
        {
            ushort val = 123;
            val.Milliseconds().Should().Be(TimeSpan.FromMilliseconds(val));
        }

        [Test]
        public void Should_turn_int_into_Milliseconds()
        {
            int val = 123;
            val.Milliseconds().Should().Be(TimeSpan.FromMilliseconds(val));
        }

        [Test]
        public void Should_turn_long_into_Milliseconds()
        {
            long val = 123;
            val.Milliseconds().Should().Be(TimeSpan.FromMilliseconds(val));
        }

        [Test]
        public void Should_turn_double_into_Milliseconds()
        {
            double val = 1.23;
            val.Milliseconds().Should().Be(TimeSpan.FromMilliseconds(val));
        }

        [Test]
        public void Should_turn_ushort_into_Seconds()
        {
            ushort val = 123;
            val.Seconds().Should().Be(TimeSpan.FromSeconds(val));
        }

        [Test]
        public void Should_turn_int_into_Seconds()
        {
            int val = 123;
            val.Seconds().Should().Be(TimeSpan.FromSeconds(val));
        }

        [Test]
        public void Should_turn_long_into_Seconds()
        {
            long val = 123;
            val.Seconds().Should().Be(TimeSpan.FromSeconds(val));
        }

        [Test]
        public void Should_turn_double_into_Seconds()
        {
            double val = 1.23;
            val.Seconds().Should().Be(TimeSpan.FromSeconds(val));
        }

        [Test]
        public void Should_turn_ushort_into_Minutes()
        {
            ushort val = 123;
            val.Minutes().Should().Be(TimeSpan.FromMinutes(val));
        }

        [Test]
        public void Should_turn_int_into_Minutes()
        {
            int val = 123;
            val.Minutes().Should().Be(TimeSpan.FromMinutes(val));
        }

        [Test]
        public void Should_turn_long_into_Minutes()
        {
            long val = 123;
            val.Minutes().Should().Be(TimeSpan.FromMinutes(val));
        }

        [Test]
        public void Should_turn_double_into_Minutes()
        {
            double val = 1.23;
            val.Minutes().Should().Be(TimeSpan.FromMinutes(val));
        }

        [Test]
        public void Should_turn_ushort_into_Hours()
        {
            ushort val = 123;
            val.Hours().Should().Be(TimeSpan.FromHours(val));
        }

        [Test]
        public void Should_turn_int_into_Hours()
        {
            int val = 123;
            val.Hours().Should().Be(TimeSpan.FromHours(val));
        }

        [Test]
        public void Should_turn_long_into_Hours()
        {
            long val = 123;
            val.Hours().Should().Be(TimeSpan.FromHours(val));
        }

        [Test]
        public void Should_turn_double_into_Hours()
        {
            double val = 1.23;
            val.Hours().Should().Be(TimeSpan.FromHours(val));
        }

        [Test]
        public void Should_turn_ushort_into_Days()
        {
            ushort val = 123;
            val.Days().Should().Be(TimeSpan.FromDays(val));
        }

        [Test]
        public void Should_turn_int_into_Days()
        {
            int val = 123;
            val.Days().Should().Be(TimeSpan.FromDays(val));
        }

        [Test]
        public void Should_turn_long_into_Days()
        {
            long val = 123;
            val.Days().Should().Be(TimeSpan.FromDays(val));
        }

        [Test]
        public void Should_turn_double_into_Days()
        {
            double val = 1.23;
            val.Days().Should().Be(TimeSpan.FromDays(val));
        }
    }
}