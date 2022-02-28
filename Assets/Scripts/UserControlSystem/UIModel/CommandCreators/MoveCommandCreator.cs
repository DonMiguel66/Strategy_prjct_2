using System;
using SimpleStrategy3D.Abstractions;
using SimpleStrategy3D.UIView;
using SimpleStrategy3D.UserControlSystem;
using SimpleStrategy3D.Utils;
using UnityEngine;
using Zenject;

namespace SimpleStrategy3D.UIModels
{
    public class MoveCommandCreator : CommandCreatorBase<IMoveCommand>
    {
        [Inject] private AssetsContext _context;

        private Action<IMoveCommand> _creationCallback;

        [Inject]
        private void Init(Vector3Value groundClicks)
        {
            groundClicks.OnChange += OnNewValue;
        }

        private void OnNewValue(Vector3 groundClick)
        {
            _creationCallback?.Invoke(_context.Inject(new MoveUnitCommand(groundClick)));
            _creationCallback = null;
        }

        protected override void SpecificCommandCreation(Action<IMoveCommand> creationCallback)
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

