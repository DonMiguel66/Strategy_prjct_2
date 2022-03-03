using System.Threading;
using SimpleStrategy3D.Abstractions;
using SimpleStrategy3D.UIView;
using SimpleStrategy3D.Utils;
using UnityEngine;
using UnityEngine.AI;

namespace SimpleStrategy3D.UserControlSystem
{
    public class MoveUnitCommand : CommandExecutorBase<IMoveCommand>
    {
        //public Vector3 Target { get; }

        //public MoveUnitCommand(Vector3 target)
        //{
        //    Target = target;
        //}
        [SerializeField] private UnitMovementStop _stop;
        [SerializeField] private Animator _animator;
        [SerializeField] private StopUnitCommand _stopUnitCommand;

        protected override async void ExecuteSpecificCommand(IMoveCommand command)
        {
            GetComponent<NavMeshAgent>().destination = command.Target;
            _animator.SetTrigger(Animator.StringToHash(AnimationTypes.Walk));
            _stopUnitCommand.CancellationTokenSource = new CancellationTokenSource();
            try
            {
                await _stop
                    .WithCancellation
                    (
                        _stopUnitCommand
                            .CancellationTokenSource
                            .Token
                    );
            }
            catch
            {
                GetComponent<NavMeshAgent>().isStopped = true;
                GetComponent<NavMeshAgent>().ResetPath();
            }
            _stopUnitCommand.CancellationTokenSource = null;
            _animator.SetTrigger(Animator.StringToHash(AnimationTypes.Idle));
        }

    }
}