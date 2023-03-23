using ECSShooter.Factories;
using ECSShooter.Infrastructure;
using ECSShooter.Services;
using ECSShooter.Services.CoroutineRunner;
using UnityEngine;
using Zenject;

namespace ECSShooter
{
    public class GameInstaller : MonoInstaller, IInitializable
    {
        [SerializeField] 
        private CoroutineRunner _coroutineRunner;

        public override void Start()
        {
            base.Start();
            Initialize();
        }

        public void Initialize()
        {
            Container.Resolve<GameStateMachine>()
                .With(x => x.CreateStates())
                .Enter<BootstrapState>();
        }
        
        public override void InstallBindings()
        {
            InstallFactories();
            Container.Bind<ISceneLoader>()
                .To<SceneLoader>().AsSingle();

            Container.Bind<GameStateMachine>()
                .AsSingle().NonLazy();

            Container.Bind<ICoroutineRunner>()
                .To<CoroutineRunner>()
                .FromInstance(_coroutineRunner)
                .AsSingle();
        }

        private void InstallFactories()
        {
            Container.Bind<StateFactory>().AsSingle();
        }
    }
}