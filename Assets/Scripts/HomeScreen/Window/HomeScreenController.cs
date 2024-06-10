using System;
using UnityEngine;
using WindowSystem;

namespace HomeScreen
{
    public class HomeScreenController : WindowController<HomeScreenView, HomeScreenModel>
    {
        public override WindowLayer CurrentLayer => WindowLayer.Screen;
        
        public Action PlayClicked;
        
        protected override void OnApplyView(HomeScreenView view)
        {
            view.PlayClicked += OnPlayClicked;
        }

        protected override void OnCloseView(HomeScreenView view)
        {
            view.PlayClicked -= OnPlayClicked;
        }

        private void OnPlayClicked()
        {
            Debug.LogError("Play clicked!");
            PlayClicked?.Invoke();
        }
    }
}