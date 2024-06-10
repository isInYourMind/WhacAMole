using System;
using UnityEngine;
using UnityEngine.UI;
using WindowSystem;

namespace Game
{
    public class GameRulesWindowView : WindowView<GameRulesWindowModel>
    {
        public Action PlayClicked;
        
        [SerializeField] private Button _playButton;
        
        protected override void OnApplyModel(GameRulesWindowModel windowModel)
        {
            _playButton.onClick.AddListener(() => PlayClicked?.Invoke());
        }

        protected override void OnDestroyEvent()
        {
            _playButton.onClick.RemoveAllListeners();
        }
    }
}