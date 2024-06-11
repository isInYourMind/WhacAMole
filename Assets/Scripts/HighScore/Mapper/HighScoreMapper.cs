using System;
using UnityEngine;
using WindowSystem;
using Zenject;

namespace HighScore
{
    public class HighScoreMapper: IInitializable
    {
        private readonly IHighScoreFactory _highScoreFactory;
        private readonly IWindowManager _windowManager;

        public HighScoreMapper(IWindowManager windowManager, IHighScoreFactory highScoreFactory)
        {
            _highScoreFactory = highScoreFactory;
            _windowManager = windowManager;
        }
        
        public void Initialize()
        {
            _windowManager.Register<HighScoreWindowController>(delegate (Transform parent, Action<IWindowView> action)
            {
                action.Invoke(_highScoreFactory.CreateHighScoreWindowView(parent));
            });
        }
    }
}