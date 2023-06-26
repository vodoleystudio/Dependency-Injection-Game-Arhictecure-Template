using System.Collections.Generic;
using UnityEngine;

namespace Project.AppFrontendDomain.Installers
{
    public class ProjectInstallerSettings : ScriptableObject
    {
        private const string AutoLoadPrefabsParentDefaultName = "AutoLoadPrefabs";
        private const int DefaultFPSRate = 60;

        [SerializeField]
        private string _autoLoadPrefabsParentName = AutoLoadPrefabsParentDefaultName;

        public string AutoLoadPrefabsParentName => _autoLoadPrefabsParentName;

        [SerializeField]
        private List<GameObject> _autoLoadPrefabs;

        public IReadOnlyCollection<GameObject> AutoLoadPrefabs => _autoLoadPrefabs;

        [SerializeField]
        private List<GameObject> _mobileAutoLoadedPrefabs;

        public IReadOnlyCollection<GameObject> MobileAutoLoadedPrefabs => _mobileAutoLoadedPrefabs;

        [SerializeField]
        private int _fps = DefaultFPSRate;

        public int FPS => _fps;
    }
}