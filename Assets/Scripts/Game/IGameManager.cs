using System;

namespace Game
{
    public interface IGameManager
    {
        Action<int> TimeUpdated { get; set; }
        Action<int> TimeStarted { get; set; }
        Action TimeStopped { get; set; }
        Action GamePaused { get; set; }
        Action GameResumed { get; set; }
        Action SpawnMole { get; set; }
        Action<int> ScoreUpdated { get; set; }
        void ShowGameScreen();
        void StartGame();
        void PauseGame();
        void ResumeGame();
        void StopGame();
        void GetPenaltyTime();
        void GetBonusTime();
        void GetRewardScore(MoleType moleType);
    }
}