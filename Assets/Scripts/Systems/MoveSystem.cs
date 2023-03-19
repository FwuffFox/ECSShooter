using ECSShooter.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace ECSShooter.Systems
{
    public class MoveSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<Movement, UnitMovementInput>> _ecsFilter = default;
        
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _ecsFilter.Value)
            {
                ref var movement = ref _ecsFilter.Pools.Inc1.Get(entity);
                ref var input = ref _ecsFilter.Pools.Inc2.Get(entity);

                movement.characterController.Move(input.movementVector);
            }
        }
    }
}