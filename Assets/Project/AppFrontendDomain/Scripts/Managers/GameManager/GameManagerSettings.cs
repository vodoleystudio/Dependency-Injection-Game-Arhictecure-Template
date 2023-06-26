using Project.AppFrontendDomain.Modules;
using UnityEngine;

namespace Project.AppFrontendDomain.Managers
{
    public class GameManagerSettings : ScriptableObject
    {
        [SerializeField]
        private GameObject _playerPrefab;

        public GameObject PlayerPrefab => _playerPrefab;

        [SerializeField]
        private GameObject _playerBulletPrefab;

        public GameObject PlayerBulletPrefab => _playerBulletPrefab;

        private int _playerBulletsPoolInitialSize = 20;

        public int PlayerBulletsPoolInitialSize => _playerBulletsPoolInitialSize;

        [SerializeField]
        private GameObject _bubblePrefab;

        public GameObject BubblePrefab => _bubblePrefab;

        private int _bubblesPoolInitialSize = 30;

        public int BubblesPoolInitialSize => _bubblesPoolInitialSize;

        [SerializeField]
        private LevelsModuleSettings _levelsModuleSettings;

        [SerializeField]
        public LevelsModuleSettings LevelsModuleSettings => _levelsModuleSettings;

        [SerializeField]
        private GameObject _joystickPrefab;

        public GameObject JoystickPrefab => _joystickPrefab;
    }
}