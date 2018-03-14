using System;
using System.Threading;

namespace Vostok.Commons.ThreadManagment
{
    public static class ThreadRunner
    {
        public static Thread Run(Action threadRoutine, Action<Thread> tuneThreadBeforeStart = null)
        {
            var t = new Thread(ThreadRoutineWrapper.Wrap(threadRoutine))
            {
                IsBackground = true
            };
            tuneThreadBeforeStart?.Invoke(t);
            t.Start();
            return t;
        }

        public static Thread Run(Action<object> threadRoutine, object threadRoutineParameter, Action<Thread> tuneThreadBeforeStart = null)
        {
            var t = new Thread(ThreadRoutineWrapper.Wrap(threadRoutine))
            {
                IsBackground = true
            };
            tuneThreadBeforeStart?.Invoke(t);
            t.Start(threadRoutineParameter);
            return t;
        }
    }
}