using SimpleStrategy3D.Abstractions;
using UnityEngine;

namespace SimpleStrategy3D.UserControlSystem
{
    public class MoveUnitCommand : IMoveCommand
    {
        public Vector3 Target { get; }

        public MoveUnitCommand(Vector3 target)
        {
            Target = target;
        }
    }
}