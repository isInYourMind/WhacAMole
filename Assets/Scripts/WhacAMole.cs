using HomeScreen;
using UnityEngine;
using WindowSystem;
using Zenject;

public class WhacAMole : MonoBehaviour
{
    [SerializeField] private Transform _screenLayer;
    [SerializeField] private Transform _popupLayer;

    [Inject] private IWindowManager _windowManager;
    [Inject] private IHomeScreenManager _homeScreenManager;

    private void Start()
    {
        _windowManager.SetUpLayers(_screenLayer, _popupLayer);
        _homeScreenManager.OpenHomeScreen();
    }

}