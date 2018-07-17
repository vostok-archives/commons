using NSubstitute;
using NUnit.Framework;
using Vostok.Commons.Collections;

namespace Vostok.Commons.Tests.Collections
{
    [TestFixture]
    internal class PoolHandle_Tests
    {
        [SetUp]
        public void TestSetup()
        {
            pool = Substitute.For<IPool<object>>();
            resource = new object();
            handle = new PoolHandle<object>(pool, resource);
        }

        [Test]
        public void Should_release_resource_to_pool_on_disposal()
        {
            handle.Dispose();

            pool.Received().Release(resource);
        }

        private IPool<object> pool;
        private object resource;
        private PoolHandle<object> handle;
    }
}