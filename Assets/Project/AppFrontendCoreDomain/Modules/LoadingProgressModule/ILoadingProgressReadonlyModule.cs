namespace Project.AppFrontendCoreDomain.Modules
{
    public interface ILoadingProgressReadonlyModule
    {
        float Progress { get; }
        bool IsDone { get; }
    }
}