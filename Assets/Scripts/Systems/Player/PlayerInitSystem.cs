using ECSShooter.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

namespace ECSShooter.Systems.Player
{
    public class PlayerInitSystem : IEcsInitSystem
    {
        private readonly EcsPoolInject<Movement> _movementPool = default;
        private readonly EcsPoolInject<Components.Player> _playerPool = default;
        private readonly EcsPoolInject<UnitMovementInput> _unitMovementPool = default;

        private readonly EcsCustomInject<ScriptableObjects.GameData> _gameData;
        private readonly EcsCustomInject<ScriptableObjects.SceneData> _sceneData;

        public void Init(IEcsSystems systems)
        {
            var playerEntity = _playerPool.Value.GetWorld().NewEntity();
            _playerPool.Value.Add(playerEntity);
            _unitMovementPool.Value.Add(playerEntity); 
            
            ref var movement = ref _movementPool.Value.Add(playerEntity);

            var playerPrefab = _gameData.Value.playerPrefab;
            var player = Object.Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
            movement.characterController = player.GetComponent<CharacterController>();
        }
    }
}