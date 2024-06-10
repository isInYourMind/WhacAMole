using Zenject;

namespace HomeScreen
{
    public class HomeScreenInstaller : Installer<HomeScreenInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<HomeScreenManager>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<HomeScreenFactory>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<HomeScreenMapper>().AsSingle().NonLazy();
        }
    }
}