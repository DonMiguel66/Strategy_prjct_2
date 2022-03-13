using UnityEngine;
using SimpleStrategy3D.Abstractions;
using SimpleStrategy3D.Utils;

namespace SimpleStrategy3D.UIModels
{
    [CreateAssetMenu(fileName = nameof(SelectableValue), menuName = "Strategy Game/"+ nameof(SelectableValue), order = 0)]
    public class SelectableValue : StatefullScriptableObjectValueBase<ISelectable>
    {
        //public ISelectable CurrentValue { get; private set; }
        //public Action<ISelectable> OnSelected;

        //public void SetValue(ISelectable value)
        //{
        //    if (value == null && CurrentValue != null)
        //    {
        //        CurrentValue.Deselect();
        //    }
        //    base.SetValue(value);
        //    OnSelected?.Invoke(value);
        //}
    }
}
