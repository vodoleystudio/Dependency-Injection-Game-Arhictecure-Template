using Project.AppFrontendCoreDomain.Modules;
using Project.AppFrontendDomain.Modules;
using Project.AppFrontendDomain.Pang.Data.Entities;
using Project.AppFrontendDomain.Pang.Data.Saveable;
using Project.AppFrontendDomain.Signals;
using UnityEngine;
using Zenject;

namespace Project.AppFrontendDomain.Managers
{
    public class GameManager : IInitializable
    {
        private ILevelsModule _levelsModule;
        private IEntitiesCollisionsModule _entitiesCollisionsModule;
        private ISaveModule _saveModule;
        private IScenesModule _scenesModule;
        private Player _player;

        [Inject]
        private void Setup(ILevelsModule levelsModule, IEntitiesCollisionsModule entitiesCollisionsModule, ISaveModule saveModule, IScenesModule scenesModule, Player player)
        {
            _levelsModule = levelsModule;
            _entitiesCollisionsModule = entitiesCollisionsModule;
            _saveModule = saveModule;
            _scenesModule = scenesModule;
            _player = player;
        }

        public void Initialize()
        {
            Time.timeScale = 0f;

            if (_saveModule.TryGet(UserData.UserDataKey, out UserData userData))
            {
                _levelsModule.SetLevel(userData.currentLevelId);
            }
            else
            {
                SetupNewUser();
            }
        }

        public void StartGame()
        {
            Time.timeScale = 1f;
        }

        public void StopGame()
        {
            _scenesModule.ReloadScene();
        }

        public void GameplayEventsProcessing(IGameplayEvent gameplayEvent)
        {
            if (gameplayEvent is EntitiesCollisionsSignal entitiesCollisionsSignal)
            {
                _entitiesCollisionsModule.CollisionsProcessing(entitiesCollisionsSignal);
            }

            if (_player.Lives == 0)
            {
                _player.Death();
                GameLose();
                StopGame();
            }
            else if (_levelsModule.IsCurrentLevelCompleted)
            {
                GameWin();
                StopGame();
            }
        }

        private void GameLose()
        {
            // fire game lose event for update UI
        }

        private void GameWin()
        {
            // fire game win event for update UI

            var levelId = _levelsModule.GetNextLevelId();

            if (_saveModule.TryGet(UserData.UserDataKey, out UserData userData))
            {
                userData.currentLevelId = levelId;
                _saveModule.Set(UserData.UserDataKey, userData);
            }
        }

        private void SetupNewUser()
        {
            _levelsModule.SetFirstLevel();
            var newUserData = new UserData();
            newUserData.currentLevelId = _levelsModule.CurrentLevelId;
            _saveModule.Set(UserData.UserDataKey, newUserData);
        }
    }
}