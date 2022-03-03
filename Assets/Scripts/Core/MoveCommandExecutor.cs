using SimpleStrategy3D.Abstractions;
using UnityEngine;
using UnityEngine.AI;

public class MoveCommandExecutor : CommandExecutorBase<IMoveCommand>
{
    [SerializeField] private UnitMovementStop _stop;
    [SerializeField] private Animator _animator;
    [SerializeField] private NavMeshAgent _navMeshAgent;

    protected override async void ExecuteSpecificCommand(IMoveCommand command)
    {
        _navMeshAgent.destination = command.Target;
        _animator.SetTrigger("Walk");
        await _stop;
        _animator.SetTrigger("Idle");
    }
}
