using System;
using ECSShooter.Services;

namespace ECSShooter.Infrastructure
{
    public class BootstrapState : IState
    {
        private const string Bootstrap = "Bootstrap";
        private readonly GameStateMachine _gameStateMachine;
        private SceneLoader _sceneLoader;

        public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _sceneLoader.Load(Bootstrap, EnterBootstrapScene);
        }

        private void EnterBootstrapScene()
        {
            _gameStateMachine.Enter<LoadLevelState, string>("Main");
        }

        public void Exit()
        {
            throw new NotImplementedException();
        }
    }
}