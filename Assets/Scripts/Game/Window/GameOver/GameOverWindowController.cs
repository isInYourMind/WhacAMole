using WindowSystem;

namespace Game
{
    public class GameOverWindowController : WindowController<GameOverWindowView, GameOverWindowModel>
    {
        public override WindowLayer CurrentLayer => WindowLayer.Popup;
    }
}