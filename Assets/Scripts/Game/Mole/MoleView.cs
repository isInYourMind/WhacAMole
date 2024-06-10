using System;
using Cysharp.Threading.Tasks.Linq;
using MVC;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class MoleView : View<MoleModel>
    {
        public Action MoleClicked;
        
        [SerializeField] private Button _hitButton;
        [SerializeField] private Image _body;
        [SerializeField] private Image _helmet;
        [SerializeField] private Image _vikingHelmet;
        [SerializeField] private Image _bomb;
        
        protected override void OnApplyModel(MoleModel model)
        {
            _hitButton.onClick.AddListener(() => MoleClicked?.Invoke());
            model.Health.Subscribe(UpdateType);
        }

        private void UpdateType(int health)
        {
            SetType((MoleType) health);
        }

        public void SetType(MoleType type)
        {
            switch (type)
            {
                case MoleType.Regular:
                    _body.gameObject.SetActive(true);
                    _helmet.gameObject.SetActive(false);
                    _vikingHelmet.gameObject.SetActive(false);
                    _bomb.gameObject.SetActive(false);
                    break;
                case MoleType.WithHelmet:
                    _body.gameObject.SetActive(true);
                    _helmet.gameObject.SetActive(true);
                    _vikingHelmet.gameObject.SetActive(false);
                    _bomb.gameObject.SetActive(false);
                    break;
                case MoleType.WithVikingHelmet:
                    _body.gameObject.SetActive(true);
                    _helmet.gameObject.SetActive(false);
                    _vikingHelmet.gameObject.SetActive(true);
                    _bomb.gameObject.SetActive(false);
                    break;
                case MoleType.Bomb:
                    _body.gameObject.SetActive(false);
                    _helmet.gameObject.SetActive(false);
                    _vikingHelmet.gameObject.SetActive(false);
                    _bomb.gameObject.SetActive(true);
                    break;
            }
        }
        
        protected override void OnDestroyEvent()
        {
            _hitButton.onClick.RemoveAllListeners();
        }
    }
}