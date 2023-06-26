using Project.AppFrontendDomain.Pang.Data.Entities;

namespace Project.AppFrontendDomain.Data
{
    public interface ILevel
    {
        string Id { get; }

        int ActiveEnemiesCount { get; }

        void Release();

        void KillEnemy(IEnemy enemy);

        void CloneEnemy(IEnemy enemy);

        void HitEnemy(IEnemy enemy);
    }
}