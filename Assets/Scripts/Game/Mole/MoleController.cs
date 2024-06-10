using System;
using Cysharp.Threading.Tasks;
using MVC;

namespace Game
{
    public class MoleController : Controller<MoleView, MoleModel>
    {
        public Action<MoleController> Killed;
        public Action<MoleController> Exploded;
        public Action<MoleController> TimeOuted;
        public MoleType Type => Model.Type;

        private int _lifeTimeLeft;
        
        public MoleController(MoleType type)
        {
            Model.Type = new AsyncReactiveProperty<MoleType>(type);
            Model.Health.Value = (int)type;
        }
        
        protected override void OnApplyView(MoleView view)
        {
            view.SetType(Model.Type);
            view.MoleClicked += OnMoleClicked;
            _lifeTimeLeft = Model.LifeSpanSec;
            LifeBegan();
        }

        private async void LifeBegan()
        {
            while (_lifeTimeLeft > 0)
            {
                await UniTask.Delay(1000);
                _lifeTimeLeft--;
            }
            TimeOuted?.Invoke(this);
        }

        private void OnMoleClicked()
        {
            if (Model.Type == MoleType.Bomb)
            {
                Exploded?.Invoke(this);
            }
            else
            {
                switch (Model.Health.Value)
                {
                    case 1:
                        Killed?.Invoke(this);
                        break;
                    case 2:
                    case 3:
                        Model.Health.Value--;
                        break;
                }
            }
        }

        protected override void OnCloseView(MoleView view)
        {
            view.MoleClicked -= OnMoleClicked;
        }
    }
}