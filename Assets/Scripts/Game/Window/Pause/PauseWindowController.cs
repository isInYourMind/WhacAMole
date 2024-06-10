using HomeScreen;
using WindowSystem;
using Zenject;

namespace Game
{
    public class PauseWindowController : WindowController<PauseWindowView, PauseWindowModel>
    {
        [Inject] private IGameManager _gameManager;
        [Inject] private IHomeScreenManager _homeScreenManager;
        
        protected override void OnApplyView(PauseWindowView view)
        {
            view.HomeClicked += GoToHomeScreen;
            view.PlayClicked += ResumeGame;
            view.ResetRoundClicked += ResetRound;
        }

        private void ResetRound()
        {
            _gameManager.StartGame();
            Close();
        }

        private void ResumeGame()
        {
            _gameManager.ResumeGame();
            Close();
        }

        private void GoToHomeScreen()
        {
            _gameManager.StopGame();
            _homeScreenManager.OpenHomeScreen();
            Close();
        }

        protected override void OnCloseView(PauseWindowView view)
        {
            view.HomeClicked -= GoToHomeScreen;
            view.PlayClicked -= ResumeGame;
            view.ResetRoundClicked -= ResetRound;
        }
    }
}