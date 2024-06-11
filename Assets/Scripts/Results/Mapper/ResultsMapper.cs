using System;
using UnityEngine;
using WindowSystem;
using Zenject;

namespace Results
{
    public class ResultsMapper : IInitializable
    {
        private readonly IResultsFactory _resultsFactory;
        private readonly IWindowManager _windowManager;

        public ResultsMapper(IWindowManager windowManager, IResultsFactory resultsFactory)
        {
            _resultsFactory = resultsFactory;
            _windowManager = windowManager;
        }
        
        public void Initialize()
        {
            _windowManager.Register<ResultsWindowController>(delegate (Transform parent, Action<IWindowView> action)
            {
                action.Invoke(_resultsFactory.CreateResultsWindowView(parent));
            });
        }
    }
}