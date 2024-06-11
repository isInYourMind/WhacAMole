using Zenject;

namespace HighScore
{
    public class HighScoresInstaller : Installer<HighScoresInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<HighScoresManager>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<HighScoreFactory>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<HighScoreMapper>().AsSingle().NonLazy();
        }
    }
}