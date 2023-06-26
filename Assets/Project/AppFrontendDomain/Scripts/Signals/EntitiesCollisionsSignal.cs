using Project.AppFrontendDomain.Pang.Data.Entities;

namespace Project.AppFrontendDomain.Signals
{
    public class EntitiesCollisionsSignal : IGameplayEvent
    {
        private IEntity _origin;
        public IEntity Origin => _origin;

        private IEntity _collision;
        public IEntity Collision => _collision;

        public EntitiesCollisionsSignal(IEntity origin, IEntity collision)
        {
            _origin = origin;
            _collision = collision;
        }
    }
}