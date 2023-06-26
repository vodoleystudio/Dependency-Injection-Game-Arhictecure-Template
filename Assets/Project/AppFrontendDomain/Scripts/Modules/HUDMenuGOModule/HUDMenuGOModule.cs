using Project.AppFrontendDomain.Data;
using Project.AppFrontendDomain.Managers;
using Project.AppFrontendDomain.Signals;
using UnityEngine;
using UnityEngine.UI;

namespace Project.AppFrontendDomain.Modules
{
    public class HUDMenuGOModule : UIViewGOBaseModule
    {
        [SerializeField]
        private Button _backToMenu;

        public Button BackToMenu => _backToMenu;

        [SerializeField]
        private Button _shoot;

        public Button Shoot => _shoot;

        private void OnEnable()
        {
            _backToMenu.onClick.AddListener(OnBackToMainMenu);
            _shoot.onClick.AddListener(OnShoot);
        }

        private void OnDisable()
        {
            _backToMenu.onClick.RemoveListener(OnBackToMainMenu);
            _shoot.onClick.RemoveListener(OnShoot);
        }

        private void OnBackToMainMenu()
        {
            _signalBus.Fire<StopGameSignal>();
        }

        private void OnShoot()
        {
            _signalBus.Fire<PlayerShootGameSignal>();
        }
    }
}