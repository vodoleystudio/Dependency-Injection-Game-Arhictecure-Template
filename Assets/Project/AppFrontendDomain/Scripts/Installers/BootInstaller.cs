using Project.AppFrontendCoreDomain.Modules;
using UnityEngine;
using Zenject;

namespace Project.AppFrontendDomain.Installers
{
    public class BootInstaller : MonoInstaller<BootInstaller>
    {
        [SerializeField]
        private BootInstallerSettings _bootInstallerSettings;

        public override void InstallBindings()
        {
            Container.InstantiatePrefab(_bootInstallerSettings.LoadingViewGOModuleName, transform);

            Container.BindInterfacesTo<ScenesModule>().AsSingle().NonLazy();

            var scenesModule = Container.Resolve<IScenesModule>();
            scenesModule.SetupSceneAsync(_bootInstallerSettings.FirstSceneLoadingName);
        }
    }
}