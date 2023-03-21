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
        private readonly EcsCustomInject<ScriptableObjects.GameData> _gameData;
        private readonly EcsCustomInject<ScriptableObjects.SceneData> _sceneData;

        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var playerEntity = world.NewEntity();
            
            world.GetPool<Components.Player>().Add(playerEntity);
            world.GetPool<MovementInput>().Add(playerEntity);
            ref var movement = ref world.GetPool<Movement>().Add(playerEntity);
            ref var movementAnimator = ref world.GetPool<MovementAnimator>().Add(playerEntity);

            var playerPrefab = _gameData.Value.playerPrefab;
            var player = Object.Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
            
            movement.characterController = player.GetComponent<CharacterController>();
            movementAnimator.Animator = player.GetComponent<Animator>();
        }
    }
}