using System.Runtime.CompilerServices;

namespace SimpleStrategy3D.Utils
{
    public interface IAwaiter<TAwaited> : INotifyCompletion
    {
        bool IsCompleted { get; }
        TAwaited GetResult();
    }
}