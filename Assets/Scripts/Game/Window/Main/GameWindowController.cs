using System.Collections.Generic;
using WindowSystem;
using Zenject;
using Random = UnityEngine.Random;

namespace Game
{
    public class GameWindowController : WindowController<GameWindowView, GameWindowModel>
    {
        public override WindowLayer CurrentLayer => WindowLayer.Screen;

        [Inject] private IGameManager _gameManager;
        [Inject] private IGameFactory _gameFactory;
        
        private readonly List<HoleController> _holes = new();

        protected override void OnApplyView(GameWindowView view)
        {
            UpdateGame(Model.Parameters.GameRoundStartTimeSec);
            _gameManager.TimeStarted += UpdateGame;
            _gameManager.TimeUpdated += UpdateGame;
            _gameManager.SpawnMole += SpawnMoles;
            _gameManager.ScoreUpdated += UpdateScore;
            view.PauseClicked += _gameManager.PauseGame;
            foreach (var holeView in view.Holes)
            {
                _holes.Add(_gameFactory.GetHole(holeView));
            }
        }

        private void UpdateScore(int score)
        {
            View.SetScore(score);
        }

        private void UpdateGame(int timeLeft)
        {
            View.UpdateTimeLeft(timeLeft);
        }

        private void SpawnMoles()
        {
            var count = Random.Range(1, 3);
            for (var i = 0; i < count; i++)
            {
                var hole = GetRandomFreeHole();
                if (hole != null)
                {
                    var type = Random.Range(0, 4);
                    var mole = _gameFactory.GetMole(hole.MoleContainer, (MoleType) type);
                    mole.Killed += OnMoleKilled;
                    mole.Exploded += OnMoleExploded;
                    mole.TimeOuted += OnTimeOuted;
                }
            }
        }

        private void OnTimeOuted(MoleController mole)
        {
            mole.Close();
        }

        private void OnMoleExploded(MoleController mole)
        {
            mole.Close();
            _gameManager.GetPenaltyTime();
        }

        private void OnMoleKilled(MoleController mole)
        {
            if (mole.Type == MoleType.WithVikingHelmet)
            {
                _gameManager.GetBonusTime();
            }
            _gameManager.GetRewardScore(mole.Type);
            mole.Close();
        }

        private HoleController GetRandomFreeHole()
        {
            int holeIndex;
            bool allOccupied;
            
            do
            {
                holeIndex = Random.Range(0, _holes.Count);
                allOccupied = _holes.TrueForAll(hole => hole.HoleOccupied);
                if (allOccupied)
                {
                    break; 
                }
            }
            while (_holes[holeIndex].HoleOccupied);

            return allOccupied ? null : _holes[holeIndex];
        }
        
        protected override void OnCloseView(GameWindowView view)
        {
            _gameManager.TimeStarted -= UpdateGame;
            _gameManager.TimeUpdated -= UpdateGame;
            view.PauseClicked -= _gameManager.PauseGame;
            base.OnCloseView(view);
        }
    }
}