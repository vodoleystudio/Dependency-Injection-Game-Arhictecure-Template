using Project.AppFrontendDomain.Pang.Data.Entities;

namespace Project.AppFrontendDomain.Modules
{
    public interface ILevelsModule
    {
        void SetLevel(string levelId);

        void SetFirstLevel();

        string GetNextLevelId();

        void KillEnemy(IEnemy enemy);

        void HitEnemy(IEnemy enemy);

        void CloneEnemy(IEnemy enemy);

        void ReleaseLevel();

        bool IsCurrentLevelCompleted { get; }

        string CurrentLevelId { get; }
    }
}