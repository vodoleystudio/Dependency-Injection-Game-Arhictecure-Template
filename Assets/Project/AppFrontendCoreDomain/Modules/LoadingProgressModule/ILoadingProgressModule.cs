namespace Project.AppFrontendCoreDomain.Modules
{
    public interface ILoadingProgressModule : ILoadingProgressReadonlyModule
    {
        void Add(LoadingProgressData loadingProgressData);
    }
}