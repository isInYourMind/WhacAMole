using MVC;
using UnityEngine;

namespace Game
{
    public class HoleView : View<HoleModel>
    {
        public Transform MoleContainer => _moleContainer;
        
        [SerializeField] private Transform _moleContainer;
    }
}