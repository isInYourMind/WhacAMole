using Zenject;

namespace Audio
{
    public class AudioInstaller : Installer<AudioInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<AudioManager>().AsSingle().NonLazy();
        }
    }
}