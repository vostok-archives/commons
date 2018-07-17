namespace Vostok.Commons.ThreadManagment
{
    public struct ThreadPoolState
    {
        public ThreadPoolState(int minWorkerThreads, int usedThreads, int minIocpThreads, int usedIocpThreads)
            : this()
        {
            MinWorkerThreads = minWorkerThreads;
            UsedThreads = usedThreads;
            MinIocpThreads = minIocpThreads;
            UsedIocpThreads = usedIocpThreads;
        }

        public int MinWorkerThreads { get; set; }
        public int UsedThreads { get; set; }
        public int MinIocpThreads { get; set; }
        public int UsedIocpThreads { get; set; }

        public override bool Equals(object obj) =>
            !ReferenceEquals(null, obj) &&
            obj is ThreadPoolState state && Equals(state);

        public bool Equals(ThreadPoolState other) =>
            MinWorkerThreads == other.MinWorkerThreads &&
            UsedThreads == other.UsedThreads &&
            MinIocpThreads == other.MinIocpThreads &&
            UsedIocpThreads == other.UsedIocpThreads;

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = MinWorkerThreads;
                hashCode = (hashCode*397) ^ UsedThreads;
                hashCode = (hashCode*397) ^ MinIocpThreads;
                hashCode = (hashCode*397) ^ UsedIocpThreads;
                return hashCode;
            }
        }
    }
}