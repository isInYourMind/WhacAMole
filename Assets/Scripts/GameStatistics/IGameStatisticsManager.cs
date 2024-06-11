using System.Collections.Generic;

namespace GameStatistics
{
    public interface IGameStatisticsManager
    {
        Dictionary<string, int> GetHighScore { get; }
        int GetBestScoreForPlayer(string playerName);
        void SaveScoreIfBest(string playerName, int score);
    }
}