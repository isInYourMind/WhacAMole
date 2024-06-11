using UnityEngine;

namespace Game
{
    public interface IGameFactory
    {
        GameWindowView CreateGameWindowView(Transform parent);
        GameRulesWindowView CreateGameRulesWindowView(Transform parent);
        PauseWindowView CreateGamePauseWindowView(Transform parent);
        MoleController GetMole(Transform parent, MoleType moleType);
        HoleController GetHole(HoleView holeView);
    }
}