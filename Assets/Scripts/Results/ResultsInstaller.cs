using Zenject;

namespace Results
{
    public class ResultsInstaller : Installer<ResultsInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ResultsInstaller>().AsSingle().NonLazy();
        }
    }
}