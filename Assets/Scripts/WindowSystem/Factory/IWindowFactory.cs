using UnityEngine;
using WindowSystem.Window;

namespace WindowSystem.Factory
{
    public interface IWindowFactory
    {
        T CreateWindowView<T>(string path, Transform parent) where T : WindowView;
    }
}