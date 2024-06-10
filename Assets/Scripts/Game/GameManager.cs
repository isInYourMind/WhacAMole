using System;
using Cysharp.Threading.Tasks;
using WindowSystem;

namespace Game
{
    public class GameManager : IGameManager
    {
        private const int GAME_ROUND_LENGTH_SEC = 30;
        private const int BONUS_SEC = 3;
        private const int PENALTY_SEC = 3;
        private const int SPAWN_MOLE_DELAY = 2;
        
        public Action<int> TimeUpdated { get; set; }
        public Action<int> TimeStarted { get; set; }
        public Action TimeStopped { get; set; }
        public Action<int> ScoreUpdated { get; set; }
        public Action GamePaused { get; set; }
        public Action GameResumed { get; set; }
        public Action SpawnMole { get; set; }
        
        private readonly IWindowManager _windowManager;

        private int _timeLeft;
        private bool _isTimerRunning;
        private bool _isGamePaused;

        private int _currentScores;

        public GameManager(IWindowManager windowManager)
        {
            _windowManager = windowManager;
        }
        
        public void ShowGameScreen()
        {
            var parameters = new GameWindowParameters
            {
                GameRoundStartTimeSec = GAME_ROUND_LENGTH_SEC
            };
            _windowManager.Open<GameWindowController>(parameters);
            _windowManager.Open<GameRulesWindowController>();
        }

        public void StartGame()
        {
            _currentScores = 0;
            _timeLeft = GAME_ROUND_LENGTH_SEC;
            StartTimer();
        }

        private void StartTimer()
        {
            _isTimerRunning = true;
            _isGamePaused = false;
            TimeStarted?.Invoke(_timeLeft);
            TimerTick();
        }

        private async void TimerTick()
        {
            if (_isTimerRunning && _timeLeft > 0)
            {
                if (_timeLeft % SPAWN_MOLE_DELAY == 0)
                {
                    SpawnMole?.Invoke();
                }
                await UniTask.WaitUntil(() => !_isGamePaused);
                await UniTask.Delay(1000);
                _timeLeft--;
                TimeUpdated?.Invoke(_timeLeft);
                TimerTick();
            }
            else
            {
                int bestScores = 0;
                var gameOverParameters = new GameOverWindowParameters
                {
                    PlayerName = "YouLuckyToday",
                    CurrentScores = _currentScores,
                    BestScore = bestScores
                };
                _windowManager.Open<GameOverWindowController>(gameOverParameters);
                StopTimer();
            }
        }

        private void StopTimer()
        {
            _isTimerRunning = false;
            TimeStopped?.Invoke();
        }

        public void PauseGame()
        {
            _isGamePaused = true;
            _windowManager.Open<PauseWindowController>();
            GamePaused?.Invoke();
        }

        public void ResumeGame()
        {
            _isGamePaused = false;
            GamePaused?.Invoke();
        }

        public void StopGame()
        {
            StopTimer();
        }

        public void GetPenaltyTime()
        {
            _timeLeft = _timeLeft - PENALTY_SEC > 0 ? _timeLeft - PENALTY_SEC : 0;
            TimeUpdated?.Invoke(_timeLeft);
        }

        public void GetBonusTime()
        {
            _timeLeft += BONUS_SEC;
            TimeUpdated?.Invoke(_timeLeft);
        }

        public void GetRewardScore(MoleType moleType)
        {
            _currentScores += moleType switch
            {
                MoleType.WithVikingHelmet => 30,
                MoleType.WithHelmet => 20,
                MoleType.Regular => 10,
                _ => 0
            };
            ScoreUpdated?.Invoke(_currentScores);
        }
    }
}