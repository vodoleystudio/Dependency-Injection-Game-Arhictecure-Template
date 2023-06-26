using UnityEngine;

namespace Project.AppFrontendDomain.Modules
{
    public class RootViewGOModule : MonoBehaviour
    {
        [SerializeField]
        private Transform _main;

        public Transform Main => _main;

        [SerializeField]
        private Transform _menu;

        public Transform Menu => _menu;

        [SerializeField]
        private Transform _hud;

        public Transform HUD => _hud;
    }
}