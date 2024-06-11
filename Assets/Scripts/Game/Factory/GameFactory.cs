using UnityEngine;
using Zenject;

namespace Game
{
    public class GameFactory : IGameFactory
    {
        private readonly DiContainer _diContainer;

        public GameFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }
        
        public GameWindowView CreateGameWindowView(Transform parent)
        {
            var prefab = Resources.Load<GameWindowView>("Prefabs/GameWindow");
            var view = Object.Instantiate(prefab, parent);
            return view;
        }

        public GameRulesWindowView CreateGameRulesWindowView(Transform parent)
        {
            var prefab = Resources.Load<GameRulesWindowView>("Prefabs/GameRulesWindow");
            var view = Object.Instantiate(prefab, parent);
            return view;
        }

        public PauseWindowView CreateGamePauseWindowView(Transform parent)
        {
            var prefab = Resources.Load<PauseWindowView>("Prefabs/GamePauseWindow");
            var view = Object.Instantiate(prefab, parent);
            return view;
        }

        
        
        public MoleController GetMole(Transform parent, MoleType moleType)
        {
            var prefab = Resources.Load<MoleView>("Prefabs/Mole");
            var view = Object.Instantiate(prefab, parent);
            var moleController = new MoleController(moleType);
            _diContainer.Inject(moleController);
            moleController.ApplyView(view);
            return moleController;
        }
        
        public HoleController GetHole(HoleView holeView)
        {
            var holeController = new HoleController();
            _diContainer.Inject(holeController);
            holeController.ApplyView(holeView);
            return holeController;
        }
    }
}