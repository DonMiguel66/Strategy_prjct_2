using UnityEngine;

namespace SimpleStrategy3D.Abstractions
{
    public interface IPatrolCommand : ICommand
    {
        public Vector3 From { get; }
        public Vector3 To { get; }
    }
}