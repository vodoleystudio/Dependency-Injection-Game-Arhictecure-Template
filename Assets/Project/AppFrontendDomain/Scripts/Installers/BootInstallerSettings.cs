using UnityEngine;

namespace Project.AppFrontendDomain.Installers
{
    public class BootInstallerSettings : ScriptableObject
    {
        private const string FirstSceneLoadingDefaultName = "Game";

        [SerializeField]
        private string _firstSceneLoadingName = FirstSceneLoadingDefaultName;

        public string FirstSceneLoadingName => _firstSceneLoadingName;

        [SerializeField]
        private GameObject _loadingViewGOModuleName;

        public GameObject LoadingViewGOModuleName => _loadingViewGOModuleName;
    }
}