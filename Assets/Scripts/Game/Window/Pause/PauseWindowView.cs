using System;
using UnityEngine;
using UnityEngine.UI;
using WindowSystem;

namespace Game
{
    public class PauseWindowView : WindowView<PauseWindowModel>
    {
        public Action HomeClicked;
        public Action PlayClicked;
        public Action ResetRoundClicked;
        
        [SerializeField] private Button _homeButton;
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _resetRoundButton;
        
        protected override void OnApplyModel(PauseWindowModel model)
        {
            _homeButton.onClick.AddListener(() => HomeClicked?.Invoke());
            _playButton.onClick.AddListener(() => PlayClicked?.Invoke());
            _resetRoundButton.onClick.AddListener(() => ResetRoundClicked?.Invoke());
        }

        protected override void OnDestroyEvent()
        {
            _homeButton.onClick.RemoveAllListeners();
            _playButton.onClick.RemoveAllListeners();
            _resetRoundButton.onClick.RemoveAllListeners();
        }
    }
}