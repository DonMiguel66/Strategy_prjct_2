using UnityEngine;

namespace SimpleStrategy3D.Abstractions
{
    public interface ISelectable : IHealthHolder
    {
        Transform PivotPoint { get; }
        RenderTexture Icon { get; }
        void Select();
        void Deselect();
    }
}