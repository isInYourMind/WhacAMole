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

    public WhacAMole()
    {
        
    }

    private void Start()
    {
        Debug.LogError("WhacAMole started!");
        _windowManager.SetUpLayers(_screenLayer, _popupLayer);
        _homeScreenManager.OpenHomeScreen();
    }

}