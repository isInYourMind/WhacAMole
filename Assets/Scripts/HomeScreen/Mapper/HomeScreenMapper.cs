using System;
using UnityEngine;
using WindowSystem;
using Zenject;

namespace HomeScreen
{
    public class HomeScreenMapper : IInitializable
    {
        private readonly IHomeScreenFactory _homeScreenFactory;
        private readonly IWindowManager _windowManager;

        public HomeScreenMapper(IHomeScreenFactory homeScreenFactory,
            IWindowManager windowManager)
        {
            _homeScreenFactory = homeScreenFactory;
            _windowManager = windowManager;
        }

        public void Initialize()
        {
            _windowManager.Register<HomeScreenController>(delegate (Transform parent, Action<IWindowView> action)
            {
                action.Invoke(_homeScreenFactory.CreateHomeScreenView(parent));
            });
        }
    }
}