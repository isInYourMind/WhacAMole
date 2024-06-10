using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WindowSystem;

namespace Game
{
    public class GameOverWindowView : WindowView<GameOverWindowModel>
    {
        public Action ContinueClicked;
        
        [SerializeField] private TextMeshProUGUI _playerName;
        [SerializeField] private TextMeshProUGUI _score;
        [SerializeField] private TextMeshProUGUI _bestScore;
        [SerializeField] private Button _continueButton;
        
        protected override void OnApplyModel(GameOverWindowModel model)
        {
            _playerName.text = model.Parameters.PlayerName;
            _score.text = model.Parameters.CurrentScores.ToString();
            _bestScore.text = model.Parameters.BestScore.ToString();
            _continueButton.onClick.AddListener(() => ContinueClicked?.Invoke());
        }
        
        protected override void OnDestroyEvent()
        {
            _continueButton.onClick.RemoveAllListeners();
        }
    }
}