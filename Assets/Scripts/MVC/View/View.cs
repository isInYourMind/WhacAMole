using System;
using UnityEngine;

namespace MVC
{
    public class View<TModel> : MonoBehaviour, IView
        where TModel : class, IModel
    {
        public event Action DestroyEvent;
        
        private bool _hidden;
        
        protected TModel Model { get; private set; }
        
        private void Start()
        {
            OnStartEvent();
        }

        private void OnDestroy()
        {
            DestroyEvent?.Invoke();
            OnDestroyEvent();
        }
        
        public void Disable()
        {
            gameObject.SetActive(false);
        }

        public void ApplyModel(IModel model)
        {
            Model = model as TModel;
            OnApplyModel(Model);
        }

        protected virtual void OnApplyModel(TModel model)
        {
        }

        protected virtual void OnStartEvent()
        {
        }

        protected virtual void OnDestroyEvent()
        {
        }
    }
}