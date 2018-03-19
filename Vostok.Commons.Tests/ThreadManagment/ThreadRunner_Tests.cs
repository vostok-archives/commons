using System;
using System.Threading;
using FluentAssertions;
using NUnit.Framework;
using Vostok.Commons.Convertions;
using Vostok.Commons.Testing;
using Vostok.Commons.ThreadManagment;

namespace Vostok.Commons.Tests.ThreadManagment
{
    [TestFixture]
    public class ThreadRunner_Tests
    {
        public static int SomeValue { get; set; }
        public static int SomeValueParam { get; set; }

        [Test]
        public void Run_should_run_thread()
        {
            new Action(Run_should_run_thread_test).ShouldPassIn(300.Milliseconds());
        }
        public void Run_should_run_thread_test()
        {
            var thread = ThreadRunner.Run(() => SomeValue = 123);
            thread.IsBackground.Should().BeTrue();
            Thread.Sleep(200);
            SomeValue.Should().Be(123);
        }

        [Test]
        public void Run_should_run_thread_with_parameters()
        {
            new Action(Run_should_run_thread_with_parameters_test).ShouldPassIn(300.Milliseconds());
        }
        public void Run_should_run_thread_with_parameters_test()
        {
            var thread = ThreadRunner.Run(obj => SomeValueParam = (int) obj, 321);
            thread.IsBackground.Should().BeTrue();
            Thread.Sleep(200);
            SomeValueParam.Should().Be(321);
        }
    }
}