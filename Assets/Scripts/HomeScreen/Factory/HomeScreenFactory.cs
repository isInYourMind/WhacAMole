using UnityEngine;

namespace HomeScreen
{
    public class HomeScreenFactory : IHomeScreenFactory
    {
        public HomeScreenView CreateHomeScreenView(Transform parent)
        {
            var prefab = Resources.Load<HomeScreenView>("Prefabs/HomeScreen");
            if (prefab == null)
            {
                return null;
            }

            var view = Object.Instantiate(prefab, parent);
            return view;
        }
    }
}