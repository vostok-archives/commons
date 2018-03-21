using System;
using System.Threading;
using FluentAssertions;
using NUnit.Framework;
using Vostok.Commons.Conversions;
using Vostok.Commons.Testing;
using Vostok.Commons.Time;

namespace Vostok.Commons.Tests.Time
{
    [TestFixture]
    public class TimeBudget_Tests
    {
        [Test]
        public void Should_StartNew_from_TimeSpan()
        {
            var ts = new TimeSpan(0, 0, 10);
            TimeBudget.StartNew(ts).Should().BeEquivalentTo(new TimeBudget(ts));
        }

        [Test]
        public void Should_StartNew_from_TimeSpan_with_precision()
        {
            var ts = new TimeSpan(0, 0, 10);
            var prec = new TimeSpan(0, 0, 10);
            TimeBudget.StartNew(ts, prec).Should().BeEquivalentTo(new TimeBudget(ts, prec));
        }

        [Test]
        public void Should_StartNew_from_milliseconds()
        {
            var ms = 100;
            TimeBudget.StartNew(ms).Should().BeEquivalentTo(new TimeBudget(TimeSpan.FromMilliseconds(ms)));
        }

        [Test]
        public void Should_StartNew_from_milliseconds_with_precision()
        {
            var ms = 100;
            var prec = 100;
            TimeBudget.StartNew(ms, prec).Should().BeEquivalentTo(
                new TimeBudget(TimeSpan.FromMilliseconds(ms), TimeSpan.FromMilliseconds(prec)));
        }

        [Test]
        public void Properties_should_return_correct_values()
        {
            var budget = new TimeSpan(100);
            var prec = new TimeSpan(10);
            var tb = new TimeBudget(budget, prec);
            tb.Budget.Should().Be(budget);
            tb.Precision.Should().Be(prec);
        }

        [Test]
        public void Elapsed_should_return_correct_value()
        {
            var time = 100;
            new Action(() =>
            {
                var tb = TimeBudget.StartNew(1000);
                Thread.Sleep(time);
                tb.Elapsed().Should()
                    .BeGreaterOrEqualTo(new TimeSpan(0, 0, 0, 0, time))
                    .And
                    .BeLessOrEqualTo(new TimeSpan(0, 0, 0, 0, (int) (time * 1.5)));
            }).ShouldPassIn((time * 2).Milliseconds());
        }
        
        private TimeSpan Remaining_test(int time, int budget, int prec)
        {
            var tb = TimeBudget.StartNew(budget, prec);
            Thread.Sleep(time);
            return tb.Remaining();
        }
        [Test]
        public void Remaining_should_return_correct_value()
        {
            var time = 123;
            new Action(() => Remaining_test(time, 1000, 1000).Should()
                .Be(TimeSpan.Zero)).ShouldPassIn((time * 2).Milliseconds());
            new Action(() => Remaining_test(time, 1000, 500).Should()
                .BeGreaterThan(new TimeSpan(0, 0, 0, 0, 500))).ShouldPassIn((time * 2).Milliseconds());
        }

        private bool HasExpired_test(int time, int budget, int prec)
        {
            var tb = TimeBudget.StartNew(budget, prec);
            Thread.Sleep(time);
            return tb.HasExpired();
        }
        [Test]
        public void HasExpired_should_return_correct_value()
        {
            var time = 123;
            new Action(() => HasExpired_test(time, 1000, 1000).Should()
                .BeTrue()).ShouldPassIn((time * 2).Milliseconds());
            new Action(() => HasExpired_test(time, 1000, 500).Should()
                .BeFalse()).ShouldPassIn((time * 2).Milliseconds());
        }

        private TimeSpan TryAcquireTime_test(int time, int budget, int prec, int need)
        {
            var tb = TimeBudget.StartNew(budget, prec);
            Thread.Sleep(time);
            return tb.TryAcquireTime(new TimeSpan(need));
        }
        [Test]
        public void TryAcquireTime_should_return_correct_value()
        {
            var time = 123;
            var need = 123;
            new Action(() => TryAcquireTime_test(time, 1000, 1000, need).Should()
                .Be(TimeSpan.Zero)).ShouldPassIn((time * 2).Milliseconds());
            new Action(() => TryAcquireTime_test(time, 1000, 500, need).Should()
                .Be(new TimeSpan(need))).ShouldPassIn((time * 2).Milliseconds());
        }
    }
}