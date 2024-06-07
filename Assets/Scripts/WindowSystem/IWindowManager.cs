using MVC;
using UnityEngine;
using WindowSystem.Window;

namespace WindowSystem
{
    public interface IWindowManager
    {
        void SetUpLayers(Transform screenLayer, Transform popupLayer);
        TController Open<TController>(IParameters parameters) where TController : WindowController, new();
    }
}