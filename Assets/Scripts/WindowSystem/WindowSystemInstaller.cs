using Zenject;

namespace WindowSystem
{
    public class WindowSystemInstaller : Installer<WindowSystemInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<WindowManager>().AsSingle().NonLazy();
        }
    }
}