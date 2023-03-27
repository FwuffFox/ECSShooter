using ECSShooter.Factories;
using ECSShooter.Infrastructure;
using ECSShooter.Services;
using ECSShooter.Services.CoroutineRunner;
using ECSShooter.Services.Input;
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
            
            Container.Bind<GameStateMachine>()
                .AsSingle().NonLazy();
        }

        private void InstallFactories()
        {
            Container.Bind<StateFactory>().AsSingle();
        }
    }
}