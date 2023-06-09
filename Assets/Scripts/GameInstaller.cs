using ECSShooter.Factories;
using ECSShooter.Infrastructure;
using ECSShooter.Infrastructure.States;
using ECSShooter.Services;
using ECSShooter.Services.CoroutineRunner;
using ECSShooter.Services.Input;
using ECSShooter.Services.ObjectSpawner;
using ECSShooter.Services.PersistentProgress;
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
            GameStateMachine gameStateMachine = Container.Resolve<GameStateMachine>();
            gameStateMachine.CreateStates();
            gameStateMachine.Enter<BootstrapState>();
        }
        
        public override void InstallBindings()
        {
            InstallFactories();
            Container.Bind<ISceneLoader>()
                .To<SceneLoader>().AsSingle();

            Container.Bind<ICoroutineRunner>()
                .To<CoroutineRunner>()
                .FromInstance(_coroutineRunner)
                .AsSingle();

            Container.Bind<InputService>().AsSingle();
            Container.Bind<PrefabFactory>().AsSingle();
            Container.Bind<UnitSpawner>().AsSingle();
            Container.Bind<PersistentProgress>().AsSingle();
            
            Container.Bind<GameStateMachine>()
                .AsSingle().NonLazy();
        }

        private void InstallFactories()
        {
            Container.Bind<StateFactory>().AsSingle();
        }
    }
}