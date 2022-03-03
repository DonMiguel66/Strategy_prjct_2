using System.Threading;
using SimpleStrategy3D.Abstractions;

namespace SimpleStrategy3D.UIView
{
    public class StopUnitCommand : CommandExecutorBase<IStopCommand>
    {
        public CancellationTokenSource CancellationTokenSource { get; set; }

        protected override void ExecuteSpecificCommand(IStopCommand command)
        {
            CancellationTokenSource?.Cancel();
        }
    }
}