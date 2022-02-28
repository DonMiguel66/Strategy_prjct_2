using UnityEngine;

namespace SimpleStrategy3D.Abstractions
{
    public interface IMoveCommand : ICommand
    {
        public Vector3 Target { get; }
    }
}