using System;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Vostok.Commons.Collections;

namespace Vostok.Commons.Tests.Collections
{
    [TestFixture]
    internal class Pool_Tests
    {
        [SetUp]
        public void TestSetup()
        {
            resourceFactory = Substitute.For<Func<object>>();
            resourceFactory().Returns(_ => new object());
            pool = new Pool<object>(resourceFactory);
        }

        [Test]
        public void Acquire_should_use_factory_delegate_to_allocate_new_resource()
        {
            var resource = new object();
            resourceFactory().Returns(resource);

            var acquiredResource = pool.Acquire();

            acquiredResource.Should().BeSameAs(resource);
        }

        [Test]
        public void Acquire_should_allocate_new_resource_when_there_are_no_free()
        {
            for (var i = 1; i <= 10; i++)
                pool.Acquire();

            pool.Allocated.Should().Be(10);
            pool.Available.Should().Be(0);
        }

        [Test]
        public void Release_should_return_acquired_resource_to_pool()
        {
            var resource = pool.Acquire();
            var availableBeforeRelease = pool.Available;

            pool.Release(resource);
            var availableAfterRelease = pool.Available;

            availableBeforeRelease.Should().Be(0);
            availableAfterRelease.Should().Be(1);
        }

        [Test]
        public void Acquire_should_reuse_existing_resource_if_possible()
        {
            var resource1 = pool.Acquire();

            pool.Release(resource1);

            var resource2 = pool.Acquire();

            resource2.Should().BeSameAs(resource1);
        }

        [Test]
        public void Acquire_should_reuse_existing_resources_in_fifo_order()
        {
            var resource1 = pool.Acquire();
            var resource2 = pool.Acquire();

            pool.Release(resource2);
            pool.Release(resource1);

            for (var i = 0; i < 5; i++)
            {
                var resource = pool.Acquire();

                resource.Should().BeSameAs(resource2);

                pool.Release(resource);

                resource = pool.Acquire();

                resource.Should().BeSameAs(resource1);

                pool.Release(resource);
            }
        }

        [Test]
        public void AcquireHandle_should_return_handle_that_releases_resource_on_disposal()
        {
            using (pool.AcquireHandle())
            {
            }

            pool.Allocated.Should().Be(1);
            pool.Available.Should().Be(1);
        }

        [Test]
        public void Dispose_should_dispose_resources_if_possible()
        {
            var disposable = Substitute.For<IDisposable>();
            resourceFactory().Returns(disposable);
            pool.Release(pool.Acquire());

            pool.Dispose();

            disposable.Received().Dispose();
        }

        [Test]
        public void Dispose_should_drop_all_available_resources()
        {
            pool.Release(pool.Acquire());

            pool.Dispose();

            pool.Available.Should().Be(0);
        }

        [Test]
        public void Acquire_should_not_work_on_disposed_pool()
        {
            pool.Dispose();

            Action action = () => pool.Acquire();

            action.Should().Throw<ObjectDisposedException>();
        }

        [Test]
        public void Release_should_dispose_returned_resource_on_disposed_pool()
        {
            var resource = Substitute.For<IDisposable>();

            resourceFactory().Returns(resource);

            pool.Acquire();

            pool.Dispose();

            pool.Release(resource);

            resource.Received().Dispose();
        }

        [Test]
        public void Release_should_not_return_resource_to_storage_on_disposed_pool()
        {
            var resource = pool.Acquire();

            pool.Dispose();

            pool.Release(resource);

            pool.Available.Should().Be(0);
        }

        private Func<object> resourceFactory;
        private Pool<object> pool;
    }
}
