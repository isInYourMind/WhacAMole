using UnityEngine;
using WindowSystem.Window;

namespace WindowSystem.Factory
{
    public class WindowFactory : IWindowFactory
    {
        public T CreateWindowView<T>(string path, Transform parent) where T : WindowView
        {
            var prefab = Resources.Load<T>(path);
            if (prefab == null)
            {
                Debug.LogError($"Prefab not found at path: {path}");
                return null;
            }

            var view = Object.Instantiate(prefab, parent);
            return view;
        }
    }
}