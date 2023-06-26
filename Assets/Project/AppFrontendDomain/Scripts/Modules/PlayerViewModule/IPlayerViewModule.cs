using Project.AppFrontendDomain.Signals;

namespace Project.AppFrontendDomain.Modules
{
    public interface IPlayerViewModule
    {
        void ViewEventsProcess(IUpdateViewSignal updateViewSignal);
    }
}