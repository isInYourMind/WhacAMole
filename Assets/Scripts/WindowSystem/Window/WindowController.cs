using System;
using MVC;

namespace WindowSystem.Window
{
    public class WindowController : Controller<WindowView, WindowModel>, IWindowController
    {
        public virtual WindowLayer CurrentLayer => WindowLayer.Popup;
        public Action<WindowController> Closed;
        
        protected override void OnApplyView(WindowView view)
        {
        }

        protected override void OnCloseView(WindowView view)
        {
            Closed?.Invoke(this);
        }
    }
}