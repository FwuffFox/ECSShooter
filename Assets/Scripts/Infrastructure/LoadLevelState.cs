using ECSShooter.Logic;
using ECSShooter.Services;
using UnityEngine;
using Zenject;

namespace ECSShooter.Infrastructure
{
    internal  class LoadLevelState : IPayloadEnterState<string>, IExitState
    {
        [Inject] private readonly GameStateMachine _gameStateMachine;
        [Inject] private readonly ISceneLoader _sceneLoader;

        private IEnterState _enterStateImplementation;
        
        
        public void Enter(string sceneName)
        {
            _sceneLoader.Load(sceneName, OnSceneLoad);
        }

        private void OnSceneLoad()
        {
            
        }

        public void Exit()
        {
            
        }
    }
}