using MVC;
using UnityEngine;

namespace HomeScreen.Window
{
    public class HomeScreenController : Controller<HomeScreenView, HomeScreenModel>
    {
        protected override void OnApplyView(HomeScreenView view)
        {
            view.PlayClicked += OnPlayClicked;
        }

        protected override void OnCloseView(HomeScreenView view)
        {
            view.PlayClicked -= OnPlayClicked;
        }

        private void OnPlayClicked()
        {
        }
    }
}