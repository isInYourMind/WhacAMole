using Game.Factories;
using Game.Mapper;
using Zenject;

namespace Game
{
    public class GameInstaller : Installer<GameInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameManager>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<GameFactory>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<GameMapper>().AsSingle().NonLazy();
        }
    }
}