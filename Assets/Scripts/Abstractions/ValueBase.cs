using System;
using UnityEngine;

namespace SimpleStrategy3D.Abstractions
{
    public abstract class ValueBase<T> : ScriptableObject
    {
        public T CurrentValue { get; private set; }
        public event Action<T> OnChange = delegate { };

        public virtual void SetValue(T value)
        {
            CurrentValue = value;
            OnChange.Invoke(value);
        }
    }
}
