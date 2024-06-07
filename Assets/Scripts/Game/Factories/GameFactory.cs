using Game.Mole;
using UnityEngine;

namespace Game.Factories
{
    public class GameFactory : IGameFactory
    {
        private const string MOLE_PATH = "";
        
        public GameFactory()
        {
            
        }
        

        public MoleController GetMole(MoleType moleType)
        {
            var pathSuffix = moleType == MoleType.Regular ? "" : moleType.ToString();
            var moleView = Resources.Load<MoleView>(MOLE_PATH + pathSuffix);
            var moleController = new MoleController();
            moleController.ApplyView(moleView);
            return moleController;
        }
    }
}