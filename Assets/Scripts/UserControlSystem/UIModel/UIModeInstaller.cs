using SimpleStrategy3D.Abstractions;
using SimpleStrategy3D.Utils;
using UnityEngine;
using Zenject;

namespace SimpleStrategy3D.UIModels
{
    public class UIModeInstaller : MonoInstaller
    {
        [SerializeField] private AssetsContext _legacyContext;
        [SerializeField] private Vector3Value _vector3Value;
        [SerializeField] private AttackableValue _attackableValue;

        public override void InstallBindings()
        {
            Container.Bind<AssetsContext>().FromInstance(_legacyContext);
            Container.Bind<Vector3Value>().FromInstance(_vector3Value);
            Container.Bind<AttackableValue>().FromInstance(_attackableValue);

            Container.Bind<CommandCreatorBase<IProduceUnitCommand>>().To<ProduceUnitCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IAttackCommand>>()
                .To<AttackCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IMoveCommand>>()
                .To<MoveCommandCreator>().AsTransient();
            //Container.Bind<CommandCreatorBase<IPatrolCommand>>()
            //    .To<PatrolCommandCreator>().AsTransient();
            //Container.Bind<CommandCreatorBase<IStopCommand>>()
            //    .To<StopCommandCreator>().AsTransient();

            Container.Bind<CommandButtonsModel>().AsTransient();
        }
    }
}
