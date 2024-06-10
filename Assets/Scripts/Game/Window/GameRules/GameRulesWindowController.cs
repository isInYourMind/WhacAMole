using WindowSystem;
using Zenject;

namespace Game
{
    public class GameRulesWindowController : WindowController<GameRulesWindowView, GameRulesWindowModel>
    {
        public override WindowLayer CurrentLayer => WindowLayer.Popup;

        [Inject] private IGameManager _gameManager;
        
        protected override void OnApplyView(GameRulesWindowView windowView)
        {
            windowView.PlayClicked += OnPlayClicked;
        }

        private void OnPlayClicked()
        {
            _gameManager.StartGame();
            Close();
        }

        protected override void OnCloseView(GameRulesWindowView windowView)
        {
            windowView.PlayClicked -= OnPlayClicked;
        }
    }
}