using ECSShooter.Logic;
using ECSShooter.Services;
using ECSShooter.Services.ObjectSpawner;
using UnityEngine;
using Zenject;

namespace ECSShooter.Infrastructure
{
    internal class LoadLevelState : IPayloadEnterState<string>, IExitState
    {
        [Inject] private readonly GameStateMachine _gameStateMachine;
        [Inject] private readonly ISceneLoader _sceneLoader;
        [Inject] private readonly UnitSpawner _unitSpawner;

        private IEnterState _enterStateImplementation;
        
        
        public void Enter(string sceneName)
        {
            _sceneLoader.Load(sceneName, OnSceneLoad);
        }

        private void OnSceneLoad()
        {
            GameObject player = _unitSpawner.SpawnPlayer();
            Camera.main!.GetComponent<CameraFollow>().SetTarget(player);
        }

        public void Exit()
        {
            
        }
    }
}