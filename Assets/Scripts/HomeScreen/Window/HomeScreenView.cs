using System;
using MVC;
using UnityEngine;
using UnityEngine.UI;

namespace HomeScreen.Window
{
    public class HomeScreenView : View<HomeScreenModel>
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