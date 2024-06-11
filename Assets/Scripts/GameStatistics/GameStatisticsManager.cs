using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;

namespace GameStatistics
{
    public class GameStatisticsManager : IGameStatisticsManager
    {
        private const string HIGH_SCORES = "HIGH_SCORES";
        
        public Dictionary<string, int> GetHighScore => _highScores;
        
        private Dictionary<string, int> _highScores = new();

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

            _highScores = GetSortedDictionary(_highScores);
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
                _highScores = GetSortedDictionary(_highScores);
                var highScoreStr = JsonConvert.SerializeObject(_highScores);
                PlayerPrefs.SetString(HIGH_SCORES, highScoreStr);
                PlayerPrefs.Save();
            }
        }

        private Dictionary<string, int> GetSortedDictionary(Dictionary<string, int> source)
        {
            var sortedEnumerable = from entry in _highScores orderby entry.Value descending select entry;
            var sortedDictionary = new Dictionary<string, int>();
            foreach (var keyValuePair in sortedEnumerable)
            {
                sortedDictionary.Add(keyValuePair.Key, keyValuePair.Value);
            }

            return sortedDictionary;
        }
    }
}