using MVC;
using UnityEngine;

namespace Game
{
    public class HoleController : Controller<HoleView, HoleModel>
    {
        public Transform MoleContainer => View.MoleContainer;
        public bool HoleOccupied => MoleContainer.childCount > 0;
    }
}