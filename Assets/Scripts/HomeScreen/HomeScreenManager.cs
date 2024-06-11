using Game;
using WindowSystem;

namespace HomeScreen
{
    public class HomeScreenManager : IHomeScreenManager
    {
        private readonly IWindowManager _windowManager;
        private readonly IGameManager _gameManager;

        private HomeScreenController _homeScreenController;

        public HomeScreenManager(IWindowManager windowManager,
            IGameManager gameManager)
        {
            _windowManager = windowManager;
            _gameManager = gameManager;
        }

        public void OpenHomeScreen()
        {
            _homeScreenController = _windowManager.Open<HomeScreenController>();
            _homeScreenController.PlayClicked += StartGame;
        }

        private void StartGame()
        {
            _gameManager.ShowGameScreen();
            _homeScreenController.PlayClicked -= StartGame;
        }
    }
}