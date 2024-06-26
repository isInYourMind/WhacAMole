using System;

namespace Game
{
    public interface IGameManager
    {
        Action<int> TimeUpdated { get; set; }
        Action<int> TimeStarted { get; set; }
        Action TimeIsOver { get; set; }
        Action GamePaused { get; set; }
        Action GameResumed { get; set; }
        Action SpawnMole { get; set; }
        Action<int> ScoreUpdated { get; set; }
        void ShowGameScreen();
        void StartGame();
        void PauseGame();
        void ResumeGame();
        void StopGame();
        void AddPenaltyTime();
        void AddBonusTime();
        void AddRewardScore(MoleType moleType);
        int CurrentScore { get; }
    }
}