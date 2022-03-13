using Zenject;

namespace SimpleStrategy3D.Core
{
    public class CoreInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<TimeModel>().AsSingle();
            //Container.Bind(typeof(TimeModel), typeof(ITickable)).To(typeof(TimeModel)).AsSingle();
        }
    }
}