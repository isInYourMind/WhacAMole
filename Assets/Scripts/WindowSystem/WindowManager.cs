using System;
using System.Collections.Generic;
using MVC;
using UnityEngine;
using WindowSystem.Factory;
using WindowSystem.Window;

namespace WindowSystem
{
    public class WindowManager : IWindowManager
    {
        private readonly IWindowFactory _windowFactory;
        
        private readonly Dictionary<Type, string> _windowPaths = new();
        private WindowController _currentMainWindow;
        private WindowController _currentPopupWindow;
        private Transform _screenLayer;
        private Transform _popupLayer;

        public WindowManager(IWindowFactory windowFactory)
        {
            _windowFactory = windowFactory;
        }

        public void SetUpLayers(Transform screenLayer, Transform popupLayer)
        {
            _screenLayer = screenLayer;
            _popupLayer = popupLayer;
        }
        
        public TController Open<TController>(IParameters parameters)
            where TController : WindowController, new()
        {
            var type = typeof(TController);
            if (!_windowPaths.ContainsKey(type))
            {
                Debug.LogError($"Window of type {type} is not registered.");
                return null;
            }
            
            var path = _windowPaths[type];
            var controller = CreateWindowController<TController>(path);
            if (controller == null)
            {
                Debug.LogError($"Failed to create window controller of type {type}");
                return null;
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

            controller.Open(parameters);
            return controller;
        }

        public void Register<TController>(string path) where TController : class, IWindowController 
        {
            var type = typeof(TController);
            if (!_windowPaths.TryAdd(type, path))
            {
                Debug.LogError($"Window of type {type} is already registered.");
            }
        }
        
        private TController CreateWindowController<TController>(string path) where TController : WindowController, new()
        {
            var controller = new TController();
            var view = _windowFactory.CreateWindowView<WindowView>(path, controller.CurrentLayer == WindowLayer.Screen ? _screenLayer : _popupLayer);
            if (view == null)
            {
                Debug.LogError($"Failed to create window view from path: {path}");
                controller.Close();
                return null;
            }
            controller.ApplyView(view);
            return controller;
        }

        private void CloseCurrentWindow(ref WindowController currentWindow)
        {
            if (currentWindow != null)
            {
                currentWindow.Close();
                currentWindow = null;
            }
        }
    }
}