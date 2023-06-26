using System.Threading.Tasks;

namespace Project.AppFrontendCoreDomain.Modules
{
    public interface IScenesModule
    {
        Task SetupSceneAsync(string name);

        void LoadScene(string name);

        void ReloadScene();

        void SetActiveScene(string name);

        void UnloadCurrentSceneAsync();
    }
}