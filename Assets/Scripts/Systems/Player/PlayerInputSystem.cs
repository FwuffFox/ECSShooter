using System;
using ECSShooter.Components;
using ECSShooter.Services;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace ECSShooter.Systems.Player
{
    public class PlayerInputSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<Components.Player, MovementInput>> _ecsFilter = default;

        private readonly EcsCustomInject<InputService> _inputInject = default;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _ecsFilter.Value)
            {
                var movement = _inputInject.Value.GetMovement();
                ref var playerInput = ref _ecsFilter.Pools.Inc2.Get(entity);
                
                playerInput.movementVector =
                    new Vector3(movement.x, 0, movement.y);
                
                playerInput.jump = Input.GetKeyDown(KeyCode.Space);
            }
        }
    }
}