namespace Project.AppFrontendCoreDomain.Modules
{
    public interface ISaveModule
    {
        bool TryGet<T>(string key, out T data);

        void Set<T>(string name, T data);
    }
}