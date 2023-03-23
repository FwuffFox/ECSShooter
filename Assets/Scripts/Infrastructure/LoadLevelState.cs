using ECSShooter.Services;
using UnityEngine;

namespace ECSShooter.Infrastructure
{
    internal  class LoadLevelState : IPayloadedEnterState<string>, IExitState, IUpdatableState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private IEnterState _enterStateImplementation;

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

        public void Update()
        {
            Debug.Log("Update from " + nameof(LoadLevelState));
        }
    }
}