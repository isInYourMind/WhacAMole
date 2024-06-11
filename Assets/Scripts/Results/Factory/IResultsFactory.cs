using UnityEngine;

namespace Results
{
    public interface IResultsFactory
    {
        ResultsWindowView CreateResultsWindowView(Transform parent);
    }
}