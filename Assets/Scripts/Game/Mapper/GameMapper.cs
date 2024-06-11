using System;
using UnityEngine;
using WindowSystem;
using Zenject;

namespace Game.Mapper
{
    public class GameMapper : IInitializable
    {
        private readonly IWindowManager _windowManager;
        private readonly IGameFactory _gameFactory;

        public GameMapper(IWindowManager windowManager,
            IGameFactory gameFactory)
        {
            _windowManager = windowManager;
            _gameFactory = gameFactory;
        }

        public void Initialize()
        {
            _windowManager.Register<GameWindowController>(delegate (Transform parent, Action<IWindowView> action)
            {
                action.Invoke(_gameFactory.CreateGameWindowView(parent));
            });
            _windowManager.Register<GameRulesWindowController>(delegate (Transform parent, Action<IWindowView> action)
            {
                action.Invoke(_gameFactory.CreateGameRulesWindowView(parent));
            });
            _windowManager.Register<PauseWindowController>(delegate (Transform parent, Action<IWindowView> action)
            {
                action.Invoke(_gameFactory.CreateGamePauseWindowView(parent));
            });
        }
    }
}