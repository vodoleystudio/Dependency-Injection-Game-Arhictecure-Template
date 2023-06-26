using Project.AppFrontendDomain.Pang.Data.Entities;
using Project.AppFrontendDomain.Signals;
using Zenject;

namespace Project.AppFrontendDomain.Modules
{
    public class EntitiesCollisionsModule : IEntitiesCollisionsModule
    {
        private ILevelsModule _levelsModule;

        [Inject]
        private void Setup(ILevelsModule levelsModule)
        {
            _levelsModule = levelsModule;
        }

        public void CollisionsProcessing(EntitiesCollisionsSignal entitiesCollisionsData)
        {
            if (entitiesCollisionsData.Origin is Bubble bubble)
            {
                if (entitiesCollisionsData.Collision is Bullet bullet)
                {
                    bullet.Death();

                    _levelsModule.HitEnemy(bubble);
                    _levelsModule.CloneEnemy(bubble);
                    _levelsModule.KillEnemy(bubble);
                }
            }
            else if (entitiesCollisionsData.Origin is Player player)
            {
                if (entitiesCollisionsData.Collision is Bubble)
                {
                    player.Hit();

                    if (player.Lives == 0)
                    {
                        player.Death();
                    }
                }
            }
            else if (entitiesCollisionsData.Origin is Platform platform)
            {
                if (entitiesCollisionsData.Collision is Bullet)
                {
                    platform.Hit();

                    if (platform.Lives == 0)
                    {
                        platform.Death();
                    }
                }
            }
        }
    }
}