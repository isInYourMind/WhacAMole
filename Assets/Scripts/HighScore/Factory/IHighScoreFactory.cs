using UnityEngine;

namespace HighScore
{
    public interface IHighScoreFactory
    {
        HighScoreWindowView CreateHighScoreWindowView(Transform parent);
        ScrollItemView CreateScrollItemView(Transform parent);
    }
}