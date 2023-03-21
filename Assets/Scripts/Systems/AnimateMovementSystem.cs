using ECSShooter.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace ECSShooter.Systems
{
    public class AnimateMovementSystem : IEcsRunSystem
    {
        private readonly int Moving = Animator.StringToHash(nameof(Moving));

        private EcsFilterInject<Inc<MovementInput, MovementAnimator>> _filter;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                ref var movementInput = ref _filter.Pools.Inc1.Get(entity);
                ref var movementAnimator = ref _filter.Pools.Inc2.Get(entity);
                movementAnimator.Animator.SetBool(Moving,
                    movementInput.movementVector != Vector3.zero);
                // TODO: Finish
            }
        }
    }
}