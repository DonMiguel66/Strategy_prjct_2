using System;
using SimpleStrategy3D.Abstractions;
using UnityEngine;

namespace SimpleStrategy3D.UIModels
{
    [CreateAssetMenu(fileName = nameof(AttackableValue), menuName = "Strategy Game/" + nameof(AttackableValue), order = 0)]
    public class AttackableValue : ScriptableObjectValueBase<IAttackable>
    {
        public IAttackable CurrentValue { get; private set; }
        public Action<IAttackable> OnChange;

        public void SetValue(IAttackable value)
        {
            if (value == null && CurrentValue != null)
            {
                CurrentValue.Deselect();
            }
            CurrentValue = value;
            CurrentValue?.Select();
            OnChange?.Invoke(value);
        }
    }
}
