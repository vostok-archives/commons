using System.Threading.Tasks;

namespace Vostok.Commons.Extensions
{
    public static class TaskExtensions
    {
        public static Task SilentlyContinue(this Task source) => source.ContinueWith(_ => { });
    }
}