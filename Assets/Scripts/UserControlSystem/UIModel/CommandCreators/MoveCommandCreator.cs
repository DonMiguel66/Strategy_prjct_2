using SimpleStrategy3D.Abstractions;
using SimpleStrategy3D.UserControlSystem;
using UnityEngine;

namespace SimpleStrategy3D.UIModels
{
    public class MoveCommandCreator : CancellableCommandCreatorBase<IMoveCommand, Vector3>
    {
        protected override IMoveCommand CreateCommand(Vector3 argument) => new MoveUnitCommand(argument);

    }
}

