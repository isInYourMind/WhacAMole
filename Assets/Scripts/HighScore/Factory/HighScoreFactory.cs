using UnityEngine;

namespace HighScore
{
    public class HighScoreFactory : IHighScoreFactory
    {
        public HighScoreWindowView CreateHighScoreWindowView(Transform parent)
        {
            var prefab = Resources.Load<HighScoreWindowView>("Prefabs/HighScoreWindow");
            var view = Object.Instantiate(prefab, parent);
            return view;
        }
        
        public ScrollItemView CreateScrollItemView(Transform parent)
        {
            var prefab = Resources.Load<ScrollItemView>("Prefabs/HighScoreItem");
            var view = Object.Instantiate(prefab, parent);
            return view;
        }
    }
}