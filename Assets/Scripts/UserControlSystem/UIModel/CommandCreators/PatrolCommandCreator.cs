using System;
using UnityEngine;
using Zenject;
using SimpleStrategy3D.Abstractions;
using SimpleStrategy3D.UIView;
using SimpleStrategy3D.UserControlSystem;
using SimpleStrategy3D.Utils;

namespace SimpleStrategy3D.UIModels
{
    public class PatrolCommandCreator : CommandCreatorBase<IPatrolCommand>
    {
		[Inject] private AssetsContext _context;
        [Inject] private SelectableValue _selectable;

        private Action<IPatrolCommand> _creationCallback;

        [Inject]
        private void Init(Vector3Value groundClicks)
        {
            groundClicks.OnChange += onNewValue;
        }

        private void onNewValue(Vector3 groundClick)
        {
            _creationCallback?.Invoke(_context.Inject(new PatrolCommand(_selectable.CurrentValue.PivotPoint.position, groundClick)));
            _creationCallback = null;
        }

        protected override void SpecificCommandCreation(Action<IPatrolCommand> creationCallback)
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
