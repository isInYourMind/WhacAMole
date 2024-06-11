using Game;
using GameStatistics;
using Player;
using WindowSystem;

namespace Results
{
    public class ResultsManager : IResultsManager
    {
        private readonly IWindowManager _windowManager;
        private readonly IGameManager _gameManager;
        private readonly IGameStatisticsManager _gameStatisticsManager;
        private readonly IPlayerManager _playerManager;

        public ResultsManager(
            IWindowManager windowManager, 
            IGameManager gameManager,
            IGameStatisticsManager gameStatisticsManager,
            IPlayerManager playerManager)
        {
            _windowManager = windowManager;
            _gameManager = gameManager;
            _gameStatisticsManager = gameStatisticsManager;
            _playerManager = playerManager;

            _gameManager.TimeIsOver += ShowResults;
        }

        private void ShowResults()
        {
            _gameStatisticsManager.SaveScoreIfBest(_playerManager.PlayerName, _gameManager.CurrentScore);
            var gameOverParameters = new ResultsWindowParameters
            {
                PlayerName = _playerManager.PlayerName,
                CurrentScores = _gameManager.CurrentScore,
                BestScore = _gameStatisticsManager.GetBestScoreForPlayer(_playerManager.PlayerName)
            };
            _windowManager.Open<ResultsWindowController>(gameOverParameters);
        }
    }
}