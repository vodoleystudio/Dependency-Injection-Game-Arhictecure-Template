using Project.AppFrontendDomain.Managers;
using Project.AppFrontendDomain.Signals;
using UnityEngine;
using UnityEngine.UI;

namespace Project.AppFrontendDomain.Modules
{
    public class MainMenuGOModule : UIViewGOBaseModule
    {
        [SerializeField]
        private Button _startPlay;

        public Button StartPlay => _startPlay;

        private void OnEnable()
        {
            _startPlay.onClick.AddListener(OnStartPlay);
        }

        private void OnDisable()
        {
            _startPlay.onClick.RemoveListener(OnStartPlay);
        }

        private void OnStartPlay()
        {
            _signalBus.Fire<StartGameSignal>();
        }
    }
}