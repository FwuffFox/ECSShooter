using ECSShooter.Services;
using Zenject;

namespace ECSShooter.Infrastructure.States
{
    public class BootstrapState : IEnterState, IExitState
    {
        private const string Bootstrap = "Bootstrap";
        
        [Inject] private readonly GameStateMachine _gameStateMachine;
        [Inject] private ISceneLoader _sceneLoader;
        
        public void Enter()
        {
            _sceneLoader.Load(Bootstrap, EnterBootstrapScene);
        }

        private void EnterBootstrapScene()
        {
            _gameStateMachine.Enter<LoadProgressState>();
        }

        public void Exit()
        {
            
        }
    }
}