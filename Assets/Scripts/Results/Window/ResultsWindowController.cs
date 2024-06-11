using HighScore;
using WindowSystem;
using Zenject;

namespace Results
{
    public class ResultsWindowController : WindowController<ResultsWindowView, ResultsWindowModel>
    {
        public override WindowLayer CurrentLayer => WindowLayer.Screen;
        
        [Inject] private readonly IWindowManager _windowManager;

        protected override void OnApplyView(ResultsWindowView view)
        {
            view.ContinueClicked += GoToHighScoreScreen;
        }
        
        private void GoToHighScoreScreen()
        {
            _windowManager.Open<HighScoreWindowController>();
        }

        protected override void OnCloseView(ResultsWindowView view)
        {
            view.ContinueClicked -= GoToHighScoreScreen;
            base.OnCloseView(view);
        }
    }
}