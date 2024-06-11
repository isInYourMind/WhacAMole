using Zenject;

namespace Results
{
    public class ResultsInstaller : Installer<ResultsInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ResultsManager>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<ResultsFactory>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<ResultsMapper>().AsSingle().NonLazy();
        }
    }
}