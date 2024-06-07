using Zenject;

namespace HighScores
{
    public class HighScoresInstaller : Installer<HighScoresInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<HighScoresManager>().AsSingle().NonLazy();
        }
    }
}