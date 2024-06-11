using NUnit.Framework;

namespace GameStatistics.Editor.Tests
{
    [TestFixture]
    public class GameStatisticsTest
    {
        private IGameStatisticsManager _gameStatisticsManager;
        
        [SetUp]
        public void Setup()
        {
            _gameStatisticsManager = new GameStatisticsManager();
        }

        [TestCase("Whacamoler2000", ExpectedResult = 100)]
        [TestCase("MoleKicker", ExpectedResult = 400)]
        [TestCase("HammerMaster420", ExpectedResult = 500)]
        [TestCase("Whacamoler2000", ExpectedResult = 100)]
        [TestCase("unknownPlayer", ExpectedResult = 0)]
        [TestCase("", ExpectedResult = 0)]
        public int GetBestScoreForPlayerTest(string playerName)
        {
            return _gameStatisticsManager.GetBestScoreForPlayer(playerName);
        }

        [Test]
        public void GetHighScore()
        {
            Assert.IsTrue(_gameStatisticsManager.GetHighScore != null);
            Assert.IsTrue(_gameStatisticsManager.GetHighScore.Count > 0);
        }
    }
}