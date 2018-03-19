using System;
using System.Threading;

namespace Vostok.Commons.ThreadManagment
{
    public static class ThreadRoutineWrapper
    {
        public static ParameterizedThreadStart Wrap(Action<object> threadRoutine)
        {
            return parameter =>
            {
                try
                {
                    threadRoutine(parameter);
                }
                catch (ThreadAbortException)
                {
                    Thread.ResetAbort();
                }
                catch { /* ignored */ }
            };
        }

        public static ThreadStart Wrap(Action threadRoutine)
        {
            return () =>
            {
                try
                {
                    threadRoutine();
                }
                catch (ThreadAbortException)
                {
                    Thread.ResetAbort();
                }
                catch { /* ignored */ }
            };
        }

        public static string TryGetActionDescription(Action<object> action)
        {
            try
            {
                return $"method: {action.Method}, declaringType: {action.Method.DeclaringType}";
            }
            catch
            {
                return string.Empty;
            }
        }

        public static string TryGetActionDescription(Action action)
        {
            try
            {
                return $"method: {action.Method}, declaringType: {action.Method.DeclaringType}";
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}