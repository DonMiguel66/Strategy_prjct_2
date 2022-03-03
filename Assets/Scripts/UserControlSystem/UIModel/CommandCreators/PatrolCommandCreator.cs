using System;
using UnityEngine;
using Zenject;
using SimpleStrategy3D.Abstractions;
using SimpleStrategy3D.UserControlSystem;
using SimpleStrategy3D.Utils;

namespace SimpleStrategy3D.UIModels
{
    public class PatrolCommandCreator : CancellableCommandCreatorBase<IPatrolCommand, Vector3>
    {
        [Inject] private SelectableValue _selectable;

        protected override IPatrolCommand CreateCommand(Vector3 argument) => new PatrolCommand(_selectable.CurrentValue.PivotPoint.position, argument);
	}
}
