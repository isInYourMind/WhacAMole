using System;
using MVC;
using UnityEngine;

namespace WindowSystem
{
    public interface IWindowManager
    {
        void SetUpLayers(Transform screenLayer, Transform popupLayer);
        TController Open<TController>(IParameters parameters = null) where TController : class, IWindowController, new();
        void Register<TController>(Action<Transform, Action<IWindowView>> windowCreator) where TController : class, IWindowController;
    }
}