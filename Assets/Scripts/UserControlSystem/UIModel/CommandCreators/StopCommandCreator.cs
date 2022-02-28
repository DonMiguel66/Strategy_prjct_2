using System;
using SimpleStrategy3D.Abstractions;
using SimpleStrategy3D.UIView;
using SimpleStrategy3D.Utils;
using UnityEngine;
using Zenject;

namespace SimpleStrategy3D.UIModels
{
    public class StopCommandCreator : CommandCreatorBase<IStopCommand>
    {
        [Inject] private AssetsContext _context;
        protected override void SpecificCommandCreation(Action<IStopCommand> creationCallback)
        {
            creationCallback?.Invoke(_context.Inject(new StopUnitCommand()));
        }
    }
}
