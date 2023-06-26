using Project.AppFrontendDomain.Signals;

namespace Project.AppFrontendDomain.Modules
{
    public interface IEntitiesCollisionsModule
    {
        void CollisionsProcessing(EntitiesCollisionsSignal entitiesCollisionsData);
    }
}