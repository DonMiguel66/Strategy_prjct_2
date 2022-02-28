using System;
using SimpleStrategy3D.Abstractions;
using SimpleStrategy3D.Utils;
using SimpleStrategy3D.UserControlSystem;
using Zenject;

namespace SimpleStrategy3D.UIModels
{
    public class AttackCommandCreator : CommandCreatorBase<IAttackCommand>
    {
        [Inject] private AssetsContext _context;

        private Action<IAttackCommand> _creationCallback;

        [Inject]
        private void Init(AttackableValue groundClicks)
        {
            groundClicks.OnChange += OnNewValue;
        }

        private void OnNewValue(IAttackable attackable)
        {
            _creationCallback?.Invoke(_context.Inject(new AttackCommand(attackable)));
            _creationCallback = null;
        }

        protected override void SpecificCommandCreation(Action<IAttackCommand> creationCallback)
        {
            _creationCallback = creationCallback;
        }

        public override void ProcessCancel()
        {
            base.ProcessCancel();

            _creationCallback = null;
        }

    }
}

