﻿using System;

namespace Vostok.Commons.Collections
{
    public struct PoolHandle<T> : IDisposable
        where T : class
    {
        private readonly IPool<T> pool;

        public PoolHandle(IPool<T> pool, T resource)
        {
            this.pool = pool;
            Resource = resource;
        }

        public T Resource { get; }

        public void Dispose() => pool.Release(Resource);

        public static implicit operator T(PoolHandle<T> handle) => handle.Resource;
    }
}