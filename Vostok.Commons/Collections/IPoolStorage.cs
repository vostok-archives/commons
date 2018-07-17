namespace Vostok.Commons.Collections
{
    internal interface IPoolStorage<T>
    {
        int Count { get; }
        bool TryAcquire(out T resource);

        void Put(T resource);
    }
}