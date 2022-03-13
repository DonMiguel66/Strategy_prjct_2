using System.Threading;
using SimpleStrategy3D.Abstractions;

public class StopCommandExecutor : CommandExecutorBase<IStopCommand>
{
    public CancellationTokenSource CancellationTokenSource { get; set; }

    protected override void ExecuteSpecificCommand(IStopCommand command)
    {
        CancellationTokenSource?.Cancel();
    }
}
