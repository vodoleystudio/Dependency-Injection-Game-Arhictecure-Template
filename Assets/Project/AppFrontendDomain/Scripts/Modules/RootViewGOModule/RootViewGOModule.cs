using UnityEngine;

namespace Project.AppFrontendDomain.Modules
{
    public class RootViewGOModule : MonoBehaviour
    {
        [SerializeField]
        private Transform _main;

        public Transform Main => _main;
    }
}