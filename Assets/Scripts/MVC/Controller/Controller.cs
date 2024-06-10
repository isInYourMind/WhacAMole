using UnityEngine;

namespace MVC
{
    public class Controller<TView, TModel> : IController
        where TView : Component, IView
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

        public void SetParameters(IParameters inputData)
        {
            Model.SetParameters(inputData);
        }

        public void Close()
        {
            if (View != null)
            {
                OnCloseView(View);
                Object.Destroy(View.gameObject);
            }
            View = null;
        }

        protected virtual void OnApplyView(TView view)
        {
        }

        protected virtual void OnCloseView(TView view)
        {
        }
    }
}