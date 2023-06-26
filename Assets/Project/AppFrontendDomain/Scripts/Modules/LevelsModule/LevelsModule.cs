using Project.AppFrontendDomain.Data;
using Project.AppFrontendDomain.Pang.Data.Entities;
using System;
using System.Linq;
using Zenject;

namespace Project.AppFrontendDomain.Modules
{
    public class LevelsModule : ILevelsModule
    {
        private LevelsModuleSettings _settings;
        private DiContainer _container;
        private ILevel _currentLevel;

        public bool IsCurrentLevelCompleted => _currentLevel.ActiveEnemiesCount == 0;
        public string CurrentLevelId => _currentLevel?.Id;

        [Inject]
        private void Setup(DiContainer container, LevelsModuleSettings settings)
        {
            _container = container;
            _settings = settings;
        }

        public void SetLevel(string levelId)
        {
            ReleaseLevel();

            var levelPrefab = _settings.LevelsPrefabs.FirstOrDefault(l => l.name == levelId);
            if (levelPrefab == null)
            {
                throw new Exception($"No level found {levelId}");
            }

            _currentLevel = _container.InstantiatePrefab(levelPrefab).GetComponent<ILevel>();
        }

        public void KillEnemy(IEnemy enemy)
        {
            _currentLevel.KillEnemy(enemy);
        }

        public void ReleaseLevel()
        {
            if (_currentLevel != null)
            {
                _currentLevel.Release();
                _currentLevel = null;
            }
        }

        public void HitEnemy(IEnemy enemy)
        {
            _currentLevel.HitEnemy(enemy);
        }

        public void CloneEnemy(IEnemy enemy)
        {
            _currentLevel.CloneEnemy(enemy);
        }

        public string GetNextLevelId()
        {
            var currentIndex = _settings.LevelsPrefabs.FindIndex(l => l.name == _currentLevel.Id);

            // get next level in cycled mode
            return _settings.LevelsPrefabs[++currentIndex % _settings.LevelsPrefabs.Count].name;
        }

        public void SetFirstLevel()
        {
            var levelId = _settings.LevelsPrefabs.First().name;
            SetLevel(levelId);
        }
    }
}