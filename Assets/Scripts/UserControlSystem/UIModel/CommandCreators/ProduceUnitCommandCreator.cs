using System;
using SimpleStrategy3D.Abstractions;
using SimpleStrategy3D.UserControlSystem;
using SimpleStrategy3D.Utils;
using Zenject;

namespace SimpleStrategy3D.UIModels
{
    public class ProduceUnitCommandCreator : CancellableCommandCreatorBase<IProduceUnitCommand, ISelectable>
    {

        //[Inject] private AssetsContext _context;
        //protected override void SpecificCommandCreation(Action<IProduceUnitCommand> creationCallback)
        //{
        //    creationCallback?.Invoke(_context.Inject(new ProduceUnitCommandHeir()));
        //}
        protected override IProduceUnitCommand CreateCommand(ISelectable argument) => new ProduceUnitCommandHeir();
    }
}
