using Zenject;

namespace GameStatistics
{
    public class GameStatisticsInstaller : Installer<GameStatisticsInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameStatisticsManager>().AsSingle().NonLazy();
        }
    }
}