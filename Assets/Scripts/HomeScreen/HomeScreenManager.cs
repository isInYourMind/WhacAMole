using WindowSystem;

namespace HomeScreen
{
    public class HomeScreenManager : IHomeScreenManager
    {
        private readonly IWindowManager _windowManager;

        public HomeScreenManager(IWindowManager windowManager)
        {
            _windowManager = windowManager;
        }

        public void OpenHomeScreen()
        {
            _windowManager.Open<HomeScreenController>();
        }
    }
}