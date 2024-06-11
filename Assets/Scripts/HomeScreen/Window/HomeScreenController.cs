using Game;
using WindowSystem;
using Zenject;

namespace HomeScreen
{
    public class HomeScreenController : WindowController<HomeScreenView, HomeScreenModel>
    {
        public override WindowLayer CurrentLayer => WindowLayer.Screen;
        
        [Inject] private IGameManager _gameManager;

        protected override void OnApplyView(HomeScreenView view)
        {
            view.PlayClicked += OnPlayClicked;
        }

        protected override void OnCloseView(HomeScreenView view)
        {
            view.PlayClicked -= OnPlayClicked;
        }

        private void OnPlayClicked()
        {
            _gameManager.ShowGameScreen();
        }
    }
}