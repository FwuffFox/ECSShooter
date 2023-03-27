using ECSShooter.Data;
using ECSShooter.Logic;
using ECSShooter.Services;
using ECSShooter.Services.ObjectSpawner;
using ECSShooter.Services.PersistentProgress;
using UnityEngine;
using Zenject;

namespace ECSShooter.Infrastructure.States
{
    internal class LoadLevelState : IPayloadEnterState<string>, IExitState
    {
        [Inject] private readonly GameStateMachine _gameStateMachine;
        [Inject] private readonly ISceneLoader _sceneLoader;
        [Inject] private readonly UnitSpawner _unitSpawner;
        [Inject] private readonly PersistentProgress _progress;
        
        private IEnterState _enterStateImplementation;

        public void Enter(string sceneName)
        {
            _unitSpawner.Cleanup();
            _sceneLoader.Load(sceneName, OnSceneLoad);
        }

        private void OnSceneLoad()
        {
            GameObject player = _unitSpawner.SpawnPlayer();
            Camera.main!.GetComponent<CameraFollow>().SetTarget(player);

            foreach (IProgressReader progressReader in _unitSpawner.ProgressReaders)
            {
                progressReader.LoadProgress(_progress.Progress);
            }
        }

        public void Exit()
        {
            
        }
    }
}