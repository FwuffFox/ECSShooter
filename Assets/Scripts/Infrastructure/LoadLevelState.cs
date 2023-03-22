using ECSShooter.Services;
using UnityEngine;

namespace ECSShooter.Infrastructure
{
    internal  class LoadLevelState : IPayloadedState<string>
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private IState _stateImplementation;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }
        
        public void Enter(string sceneName)
        {
            _sceneLoader.Load(sceneName);
        }

        public void Exit()
        {
            
        }

        public void Run()
        {
            Debug.Log("Update from " + nameof(LoadLevelState));
        }
    }
}