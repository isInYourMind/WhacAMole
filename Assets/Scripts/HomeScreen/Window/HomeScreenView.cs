using System;
using UnityEngine;
using UnityEngine.UI;
using WindowSystem;

namespace HomeScreen
{
    public class HomeScreenView : WindowView<HomeScreenModel>
    {
        public Action PlayClicked;
        
        [SerializeField] private Button _playButton;
        
        protected override void OnApplyModel(HomeScreenModel model)
        {
            _playButton.onClick.AddListener(() => PlayClicked?.Invoke());
        }

        protected override void OnDestroyEvent()
        {
            _playButton.onClick.RemoveAllListeners();
        }
    }
}