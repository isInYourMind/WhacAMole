using System;
using System.Collections.Generic;
using MVC;
using UnityEngine;
using Zenject;

namespace WindowSystem
{
    public class WindowManager : IWindowManager
    {
        private readonly DiContainer _diContainer;
        private readonly Dictionary<Type, Action<Transform, Action<IWindowView>>> _viewCreators = new();
        private IWindowController _currentMainWindow;
        private IWindowController _currentPopupWindow;
        private Transform _screenLayer;
        private Transform _popupLayer;

        public WindowManager(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public void SetUpLayers(Transform screenLayer, Transform popupLayer)
        {
            _screenLayer = screenLayer;
            _popupLayer = popupLayer;
        }
        
        public TController Open<TController>(IParameters parameters = null) where TController : class, IWindowController, new()
        {
            var type = typeof(TController);
            if (!_viewCreators.ContainsKey(type))
            {
                Debug.LogError($"Window of type {type} is not registered.");
                return default;
            }
            
            var controller = CreateWindowController<TController>(parameters);
            if (controller == null)
            {
                Debug.LogError($"Failed to create window controller of type {type}");
                return default;
            }

            // Determine if it's a main window or popup
            if (controller.CurrentLayer == WindowLayer.Screen)
            {
                CloseCurrentWindow(ref _currentMainWindow);
                _currentMainWindow = controller;
            }
            else if (controller.CurrentLayer == WindowLayer.Popup)
            {
                CloseCurrentWindow(ref _currentPopupWindow);
                _currentPopupWindow = controller;
            }
            return controller;
        }

        public void Register<TController>(Action<Transform, Action<IWindowView>> windowCreator) where TController : class, IWindowController 
        {
            var type = typeof(TController);
            if (!_viewCreators.TryAdd(type, windowCreator))
            {
                Debug.LogError($"Window of type {type} is already registered.");
            }
        }
        
        private TController CreateWindowController<TController>(IParameters parameters) where TController : class, IWindowController, new()
        {
            var controller = new TController();
            controller.SetParameters(parameters);
            _diContainer.Inject(controller);
            CreateView(controller, GetLayer(controller));
            return controller;
        }

        private void CreateView<TController>(TController window, Transform parent)
            where TController : class, IWindowController, new()
        {
            _viewCreators[typeof(TController)].Invoke(parent, view =>
            {
                if (view == null)
                {
                    Debug.LogError($"Couldn't create View: {typeof(TController)}");
                    window.Close();
                    return;
                }

                window.ApplyView(view);
            });
        }

        private Transform GetLayer(IWindowController windowController)
        {
            switch (windowController.CurrentLayer)
            {
                case WindowLayer.Screen:
                    return _screenLayer;
                default:
                    return _popupLayer;
            }
        }

        private void CloseCurrentWindow(ref IWindowController currentWindow)
        {
            if (currentWindow != null)
            {
                currentWindow.Close();
                currentWindow = null;
            }
        }
    }
}