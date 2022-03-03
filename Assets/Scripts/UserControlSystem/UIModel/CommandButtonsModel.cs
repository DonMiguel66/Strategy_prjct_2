using System;
using Assets.Scripts.SimpleStrategy3D;
using SimpleStrategy3D.Abstractions;
using UnityEngine;
using Zenject;

namespace SimpleStrategy3D.UIModels
{
    public class CommandButtonsModel
    {
        public event Action<ICommandExecutor> OnCommandAccepted;
        public event Action OnCommandSent;
        public event Action OnCommandCancel;
        
        [Inject] private CommandCreatorBase<IProduceUnitCommand> _unitProducer;
        [Inject] private CommandCreatorBase<IAttackCommand> _attack;
        [Inject] private CommandCreatorBase<IMoveCommand> _move;
        //[Inject] private CommandCreatorBase<IStopCommand> _stop;
        //[Inject] private CommandCreatorBase<IPatrolCommand> _patrol;

        private bool _commandIsPending;

        public void OnCommandButtonClicked(ICommandExecutor commandExecutor)
        {
            if (_commandIsPending)
            {
                ProcessOnCancel();
            }

            _commandIsPending = true;
            OnCommandAccepted?.Invoke(commandExecutor);

            _unitProducer.ProcessCommandExecutor(commandExecutor,
                command => ExecuteCommandWrapper(commandExecutor, command));
            _attack.ProcessCommandExecutor(commandExecutor,
                command => ExecuteCommandWrapper(commandExecutor, command));
            _move.ProcessCommandExecutor(commandExecutor,
                command => ExecuteCommandWrapper(commandExecutor, command));
            //_stop.ProcessCommandExecutor(commandExecutor,
            //    command => ExecuteCommandWrapper(commandExecutor, command));
            //_patrol.ProcessCommandExecutor(commandExecutor,
            //    command => ExecuteCommandWrapper(commandExecutor, command));
        }

        private void ExecuteCommandWrapper(ICommandExecutor commandExecutor, object command)
        {
            commandExecutor.ExecuteCommand(command);
            _commandIsPending = false;
            OnCommandSent?.Invoke();
        }

        public void OnSelectionChange()
        {
            _commandIsPending = false;
            ProcessOnCancel();
        }

        private void ProcessOnCancel()
        {
            _unitProducer.ProcessCancel();
            _attack.ProcessCancel();
            OnCommandCancel?.Invoke();
            //_move.ProcessCancel();
            //_stop.ProcessCancel();
            //_patrol.ProcessCancel();
        }
    }
}
