using System;
using ECSShooter.Services;
using UnityEngine;
using Zenject;

namespace ECSShooter.Infrastructure
{
    public class BootstrapState : IEnterState, IExitState, IUpdatableState
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
            _gameStateMachine.Enter<LoadLevelState, string>("Main");
        }

        public void Exit()
        {
            
        }

        public void Update()
        {
            Debug.Log("Update from " + nameof(BootstrapState));
        }
    }
}