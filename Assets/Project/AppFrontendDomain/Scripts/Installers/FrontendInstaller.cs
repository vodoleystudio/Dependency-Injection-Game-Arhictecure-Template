using Project.AppFrontendDomain.Modules;
using Project.AppFrontendDomain.Data;
using Project.AppFrontendDomain.Managers;
using UnityEngine;
using Zenject;
using Project.AppFrontendDomain.Pang.Data.Entities;
using Project.AppFrontendDomain.Signals;
using Project.AppFrontendCoreDomain.Modules;

namespace Project.AppFrontendDomain.Installers
{
    public class FrontendInstaller : MonoInstaller<FrontendInstaller>
    {
        [SerializeField]
        private GameObject _rootViewGOModulePrefab;

        [SerializeField]
        private GameManagerSettings _gameManagerSettings;

        private GameSettings _gameSettings;

        public override void InstallBindings()
        {
            InstallFrontend();
        }

        private void InstallFrontend()
        {
            InstallSignals();
            InstallResources();
            InstallManagers();
            InstallModules();
        }

        private void InstallResources()
        {
            Container.Bind<GameSettings>().FromNewScriptableObjectResource(GameSettings.Name).AsSingle().NonLazy();
            _gameSettings = Container.Resolve<GameSettings>();
        }

        private void InstallSignals()
        {
            Container.DeclareSignal<EntitiesCollisionsSignal>();
            Container.DeclareSignal<StartGameSignal>();
            Container.DeclareSignal<StopGameSignal>();
            Container.DeclareSignal<PlayerHitSignal>();
            Container.DeclareSignal<PlayerShootGameSignal>();
        }

        private void InstallModules()
        {
            Container.BindMemoryPool<Bullet, Bullet.Pool>().
                WithInitialSize(_gameManagerSettings.PlayerBulletsPoolInitialSize).
                ExpandByOneAtATime().
                FromComponentInNewPrefab(_gameManagerSettings.PlayerBulletPrefab).
                UnderTransformGroup("PlayerBulletsPool");

            Container.BindMemoryPool<Bubble, Bubble.Pool>().
                WithInitialSize(_gameManagerSettings.BubblesPoolInitialSize).
                ExpandByOneAtATime().
                FromComponentInNewPrefab(_gameManagerSettings.BubblePrefab).
                UnderTransformGroup("BubblesPool");

            Container.Bind<RootViewGOModule>().FromComponentInNewPrefab(_rootViewGOModulePrefab).AsSingle().NonLazy();

            Container.BindInterfacesTo<ScenesModule>().AsSingle().NonLazy();
            Container.BindInterfacesTo<SaveModule>().AsSingle().NonLazy();

            Container.Bind<TagsModule>().AsSingle().NonLazy();
            Container.BindInterfacesTo<MainCameraModule>().AsSingle().WithArguments(_gameSettings.TargetAspectRatio).NonLazy();

            Container.BindInterfacesTo<EntitiesCollisionsModule>().AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<Player>().FromComponentInNewPrefab(_gameManagerSettings.PlayerPrefab).AsSingle().NonLazy();
            var player = Container.Resolve<Player>();
            Container.BindInterfacesAndSelfTo<PlayerView>().FromComponentOn(player.gameObject).AsCached().NonLazy();
            Container.BindInterfacesAndSelfTo<PlayerViewModule>().AsSingle().NonLazy();
            Container.BindSignal<PlayerHitSignal>().ToMethod<PlayerViewModule>(x => x.ViewEventsProcess).FromResolve();
            Container.BindSignal<PlayerShootGameSignal>().ToMethod<Player>(x => x.Shoot).FromResolve();

            Container.BindInterfacesTo<LevelsModule>().AsSingle().WithArguments(Container, _gameManagerSettings.LevelsModuleSettings).NonLazy();
        }

        private void InstallManagers()
        {
            Container.BindInterfacesAndSelfTo<GameManager>().AsSingle().NonLazy();
            Container.BindInitializableExecutionOrder<GameManager>(int.MaxValue);

            Container.BindSignal<StartGameSignal>().ToMethod<GameManager>(x => x.StartGame).FromResolve();
            Container.BindSignal<StopGameSignal>().ToMethod<GameManager>(x => x.StopGame).FromResolve();
            Container.BindSignal<EntitiesCollisionsSignal>().ToMethod<GameManager>(x => x.GameplayEventsProcessing).FromResolve();

            Container.BindInterfacesAndSelfTo<UIViewsManager>().AsSingle().NonLazy();
            Container.BindSignal<StartGameSignal>().ToMethod<UIViewsManager>(x => x.StartGame).FromResolve();
            Container.BindSignal<StopGameSignal>().ToMethod<UIViewsManager>(x => x.StopGame).FromResolve();
        }
    }
}