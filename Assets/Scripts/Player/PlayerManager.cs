namespace Player
{
    public class PlayerManager : IPlayerManager
    {
        public string PlayerName => _playerName;
        
        private string _playerName;

        public PlayerManager()
        {
            _playerName = "IamLuckyToday";
        }
    }
}