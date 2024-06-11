using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WindowSystem;

namespace Results
{
    public class ResultsWindowView : WindowView<ResultsWindowModel>
    {
        public Action ContinueClicked;
        
        [SerializeField] private TextMeshProUGUI _playerName;
        [SerializeField] private TextMeshProUGUI _score;
        [SerializeField] private TextMeshProUGUI _bestScore;
        [SerializeField] private Button _continueButton;
        
        protected override void OnApplyModel(ResultsWindowModel model)
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