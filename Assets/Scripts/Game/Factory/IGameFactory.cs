using UnityEngine;

namespace Game.Factories
{
    public interface IGameFactory
    {
        GameWindowView CreateGameWindowView(Transform parent);
        GameRulesWindowView CreateGameRulesWindowView(Transform parent);
        PauseWindowView CreateGamePauseWindowView(Transform parent);
        GameOverWindowView CreateGameOverWindowView(Transform parent);
        MoleController GetMole(Transform parent, MoleType moleType);
        HoleController GetHole(HoleView holeView);
    }
}