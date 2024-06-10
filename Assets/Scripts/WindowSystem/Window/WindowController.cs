using System;
using MVC;
using UnityEngine;

namespace WindowSystem
{
    public class WindowController<TView, TModel> : Controller<TView, TModel>, IWindowController 
        where TView : Component, IWindowView 
        where TModel : class, IWindowModel, IModel, new()
    {
        public virtual WindowLayer CurrentLayer => WindowLayer.Popup;
        public Action<IWindowController> Closed { get; }
        
        protected override void OnApplyView(TView view)
        {
        }

        protected override void OnCloseView(TView view)
        {
            Closed?.Invoke(this);
        }
    }
}