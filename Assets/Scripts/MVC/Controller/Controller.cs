using UnityEngine;

namespace MVC
{
    public class Controller<TView, TModel> : IController
        where TView : UnityEngine.Component, IView
        where TModel : class, IModel, new()
    {
        protected TView View { get; private set; }
        
        protected TModel Model { get; }
        
        protected Controller()
        {
            Model = new TModel();
        }
        
        public void ApplyView(IView view)
        {
            View = view as TView;
            View.ApplyModel(Model);
            OnApplyView(View);
        }

        public void Open(IParameters inputData)
        {
            View.SetOpen(State.Open);
            Model.SetParameters(inputData);
        }

        public void Close()
        {
            View.SetOpen(State.Close);
            if (View != null)
            {
                OnCloseView(View);
                Object.Destroy(View.gameObject);
            }
            View = null;
        }

        public void Hide()
        {
            View.SetOpen(State.Hide);
        }

        protected virtual void OnApplyView(TView view)
        {
        }

        protected virtual void OnCloseView(TView view)
        {
        }
    }
}