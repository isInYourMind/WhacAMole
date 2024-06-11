using System;
using UnityEngine;
using UnityEngine.UI;
using WindowSystem;

namespace HighScore
{
    public class HighScoreWindowView : WindowView<HighScoreWindowModel>
    {
        public Action ContinueClicked;
        
        [SerializeField] private Button _continueButton;
        [SerializeField] private Transform _contentContainer;

        public Transform ContentContainer => _contentContainer;
        
        protected override void OnApplyModel(HighScoreWindowModel model)
        {
            _continueButton.onClick.AddListener(() => ContinueClicked?.Invoke());
        }
        
        protected override void OnDestroyEvent()
        {
            _continueButton.onClick.RemoveAllListeners();
        }
    }
}