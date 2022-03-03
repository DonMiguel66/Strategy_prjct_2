using SimpleStrategy3D.Abstractions;
using UnityEngine.AI;

namespace SimpleStrategy3D.Core
{
    public class UnitMove : CommandExecutorBase<IMoveCommand>
    {
        protected override void ExecuteSpecificCommand(IMoveCommand command)
        {
            GetComponent<NavMeshAgent>().destination = command.Target;
        }
    }
}