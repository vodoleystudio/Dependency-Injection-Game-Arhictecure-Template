using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using Zenject;

namespace Project.AppFrontendCoreDomain.Modules
{
    public class ScenesModule : IScenesModule
    {
        private ILoadingProgressModule _loadingProgressModule;

        [Inject]
        private void Setup(ILoadingProgressModule loadingProgressModule)
        {
            _loadingProgressModule = loadingProgressModule;
        }

        public async Task SetupSceneAsync(string name)
        {
            var loadingProgressData = new LoadingProgressData();
            _loadingProgressModule.Add(loadingProgressData);
            var loader = SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
            while (!loader.isDone || !_loadingProgressModule.IsDone)
            {
                loadingProgressData.Progress = loader.progress;
                await Task.Delay(10);
            }

            await Task.Delay(500);

            UnloadCurrentSceneAsync();
            SetActiveScene(name);
        }

        public void SetActiveScene(string name)
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(name));
        }

        public void UnloadCurrentSceneAsync()
        {
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
        }

        public void LoadScene(string name)
        {
            SceneManager.LoadScene(name);
        }

        public void ReloadScene()
        {
            LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}