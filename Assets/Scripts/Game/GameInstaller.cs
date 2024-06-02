using Zenject;

namespace Game
{
    public class GameInstaller : Installer<GameInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameManager>().AsSingle().NonLazy();
        }
    }
}