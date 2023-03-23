using ECSShooter.Services;
using UnityEngine;
using Zenject;

namespace ECSShooter.Infrastructure
{
    internal  class LoadLevelState : IPayloadEnterState<string>, IExitState, IUpdatableState
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
            Object.Instantiate(Resources.Load<GameObject>("Prefabs/Player"),
                Vector3.zero, Quaternion.identity);
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