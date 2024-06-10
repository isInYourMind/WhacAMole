using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WindowSystem;

namespace Game
{
    public class GameWindowView : WindowView<GameWindowModel>
    {
        public Action PauseClicked;
        public List<HoleView> Holes => _holes;
        
        [SerializeField] private TextMeshProUGUI _scores;
        [SerializeField] private Button _pause;
        [SerializeField] private TextMeshProUGUI _timeLeft;
        [SerializeField] private List<HoleView> _holes;

        
        protected override void OnApplyModel(GameWindowModel model)
        {
            _pause.onClick.AddListener(() => PauseClicked?.Invoke());
        }
        
        protected override void OnDestroyEvent()
        {
            _pause.onClick.RemoveAllListeners();
        }
        
        public void UpdateTimeLeft(int timeLeft)
        {
            _timeLeft.text = timeLeft.ToString();
        }

        public void SetScore(int score)
        {
            _scores.text = score.ToString();
        }

        public void TimeIsUp()
        {
            _scores.text = "Time's Up!";
        }
    }
}