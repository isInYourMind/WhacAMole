using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace GameStatistics
{
    public class GameStatisticsManager : IGameStatisticsManager
    {
        private const string HIGH_SCORES = "HIGH_SCORES";
        
        public Dictionary<string, int> GetHighScore => _highScores;
        
        private readonly Dictionary<string, int> _highScores = new();

        public GameStatisticsManager()
        {
            if (PlayerPrefs.HasKey(HIGH_SCORES))
            {
                var highScoreStr = PlayerPrefs.GetString(HIGH_SCORES);
                _highScores = JsonConvert.DeserializeObject<Dictionary<string, int>>(highScoreStr);
            }
            else
            {
                _highScores = FakePlayersStatistic.PlayersStats;
            }
        }

        public int GetBestScoreForPlayer(string playerName)
        {
            return _highScores.GetValueOrDefault(playerName, 0);
        }

        public void SaveScoreIfBest(string playerName, int score)
        {
            var prevBestScore = GetBestScoreForPlayer(playerName);
            if (score > prevBestScore)
            {
                if (!_highScores.TryAdd(playerName, score))
                {
                    _highScores[playerName] = score;
                }
                var highScoreStr = JsonConvert.SerializeObject(_highScores);
                Debug.LogError(highScoreStr);
                PlayerPrefs.SetString(HIGH_SCORES, highScoreStr);
                PlayerPrefs.Save();
            }
        }
    }
}