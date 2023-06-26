using Zenject;
using UnityEngine;
using Project.AppFrontendCoreDomain.Modules;

namespace Project.AppFrontendDomain.Installers
{
    public class ProjectInstaller : MonoInstaller<ProjectInstaller>
    {
        [SerializeField]
        private ProjectInstallerSettings _projectInstallerSettings;

        public override void InstallBindings()
        {
            InstallSettings();
            InstallSignals();
            InstallInfrastructures();
            InstallAutoLoadPrefabs();
        }

        private void InstallSettings()
        {
            Application.targetFrameRate = _projectInstallerSettings.FPS;
        }

        private void InstallSignals()
        {
            SignalBusInstaller.Install(Container);
        }

        private void InstallInfrastructures()
        {
            Container.BindInterfacesTo<LoadingProgressModule>().AsSingle().NonLazy();
        }

        private void InstallAutoLoadPrefabs()
        {
            var autoLoadPrefabsParent = new GameObject(_projectInstallerSettings.AutoLoadPrefabsParentName);
            autoLoadPrefabsParent.transform.SetParent(transform);

            foreach (var autoLoadPrefab in _projectInstallerSettings.AutoLoadPrefabs)
            {
                LoadPrefab(autoLoadPrefab, autoLoadPrefabsParent.transform);
            }

#if UNITY_ANDROID || UNITY_IOS
            foreach (var mobileAutoLoadedPrefab in _projectInstallerSettings.MobileAutoLoadedPrefabs)
            {
                LoadPrefab(mobileAutoLoadedPrefab, autoLoadPrefabsParent.transform);
            }
#else
            Container.BindInterfacesTo<KeyboardModule>().AsSingle().NonLazy();
#endif
        }

        private void LoadPrefab(GameObject loadPrefab, Transform parent)
        {
            var instance = Container.InstantiatePrefab(loadPrefab, parent);
            foreach (var component in instance.GetComponents<MonoBehaviour>())
            {
                var type = component.GetType();
                Container.BindInterfacesTo(type).FromInstance(component).AsSingle().NonLazy();
            }
        }
    }
}