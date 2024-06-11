using NUnit.Framework;

namespace Player.Editor.Tests
{
    [TestFixture]
    public class PlayerTest
    {
        private IPlayerManager _playerManager;

        [SetUp]
        public void Setup()
        {
            _playerManager = new PlayerManager();
        }
        
        [Test]
        public void GetBestScoreForPlayerTest()
        {
            Assert.IsTrue(_playerManager.PlayerName != null);
            Assert.IsTrue(_playerManager.PlayerName != "");
        }
    }
}