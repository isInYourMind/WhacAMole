using UnityEngine;

namespace HomeScreen
{
    public interface IHomeScreenFactory
    {
        HomeScreenView CreateHomeScreenView(Transform parent);
    }
}