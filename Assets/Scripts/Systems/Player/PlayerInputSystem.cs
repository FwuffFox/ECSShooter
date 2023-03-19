using System;
using ECSShooter.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace ECSShooter.Systems.Player
{
    public class PlayerInputSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<Components.Player, UnitMovementInput>> _ecsFilter = default;
        
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _ecsFilter.Value)
            {
                ref var playerInput = ref _ecsFilter.Pools.Inc2.Get(entity);
                playerInput.movementVector =
                    new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                playerInput.jump = Input.GetKeyDown(KeyCode.Space);
            }
        }
    }
}