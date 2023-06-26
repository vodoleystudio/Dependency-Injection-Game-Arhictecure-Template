using Project.AppFrontendDomain.Pang.Data.Entities;
using Project.AppFrontendDomain.Signals;
using Zenject;

namespace Project.AppFrontendDomain.Modules
{
    public class PlayerViewModule : IPlayerViewModule
    {
        private IPlayerView _playerView;

        [Inject]
        private void Setup(IPlayerView playerView)
        {
            _playerView = playerView;
        }

        public void ViewEventsProcess(IUpdateViewSignal updateViewSignal)
        {
            if (updateViewSignal is PlayerHitSignal)
            {
                _playerView.PlayHitEffect();
            }
        }
    }
}