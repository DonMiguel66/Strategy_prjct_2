using UnityEngine;
using System;
using SimpleStrategy3D.Utils;

namespace SimpleStrategy3D.UIModels
{
    [CreateAssetMenu(fileName = nameof(Vector3Value), menuName = "Strategy Game/" + nameof(Vector3Value), order = 0)]
    public class Vector3Value : StatelessScriptableObjectValueBase<Vector3>
    {
        public Vector3 CurrentValue { get; private set; }
        public Action<Vector3> OnChange;

        public void SetValue(Vector3 value)
        {
            CurrentValue = value;
            OnChange?.Invoke(value);
        }
    }
}
