using GameStatistics;
using HomeScreen;
using WindowSystem;
using Zenject;

namespace HighScore
{
    public class HighScoreWindowController : WindowController<HighScoreWindowView, HighScoreWindowModel>
    {
        public override WindowLayer CurrentLayer => WindowLayer.Screen;

        [Inject] private readonly IWindowManager _windowManager;
        [Inject] private readonly IGameStatisticsManager _gameStatisticsManager;
        [Inject] private readonly IHighScoreFactory _highScoreFactory;
        
        protected override void OnApplyView(HighScoreWindowView view)
        {
            view.ContinueClicked += GoToHomeScreen;
            foreach (var playerScore in _gameStatisticsManager.GetHighScore)
            {
                var highScoreItem = _highScoreFactory.CreateScrollItemView(view.ContentContainer);
                highScoreItem.SetPlayer(playerScore.Key, playerScore.Value);
            }
        }

        private void GoToHomeScreen()
        {
            _windowManager.Open<HomeScreenController>();
        }

        protected override void OnCloseView(HighScoreWindowView view)
        {
            view.ContinueClicked -= GoToHomeScreen;
            base.OnCloseView(view);
        }
    }
}