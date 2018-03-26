using System;
using System.Threading;
using FluentAssertions;
using NUnit.Framework;
using Vostok.Commons.Conversions;
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
            new Action(RunShouldRunThreadTest).ShouldPassIn(400.Milliseconds());
        }
        private void RunShouldRunThreadTest()
        {
            var thread = ThreadRunner.Run(() =>
            {
                SomeValue = 123;
                Thread.Sleep(200);
            });
            thread.IsBackground.Should().BeTrue();
            Thread.Sleep(300);
            SomeValue.Should().Be(123);
        }

        [Test]
        public void Run_should_run_thread_with_parameters()
        {
            new Action(RunShouldRunThreadWithParametersTest).ShouldPassIn(400.Milliseconds());
        }
        private void RunShouldRunThreadWithParametersTest()
        {
            var thread = ThreadRunner.Run(obj =>
            {
                SomeValueParam = (int)obj;
                Thread.Sleep(200);
            }, 321);
            thread.IsBackground.Should().BeTrue();
            Thread.Sleep(300);
            SomeValueParam.Should().Be(321);
        }
    }
}