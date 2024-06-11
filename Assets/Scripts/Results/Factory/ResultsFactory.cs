using UnityEngine;

namespace Results
{
    public class ResultsFactory : IResultsFactory
    {
        public ResultsWindowView CreateResultsWindowView(Transform parent)
        {
            var prefab = Resources.Load<ResultsWindowView>("Prefabs/ResultsWindow");
            var view = Object.Instantiate(prefab, parent);
            return view;
        }
    }
}