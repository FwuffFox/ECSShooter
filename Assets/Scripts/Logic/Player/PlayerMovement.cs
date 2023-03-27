using System;
using ECSShooter.Services.Input;
using UnityEngine;
using Zenject;

namespace ECSShooter.Logic.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private Animator _animator;
        [SerializeField] [Range(0f, 1f)] private float _rotationLerp;

        [Inject] private InputService _input;
        private static readonly int Moving = Animator.StringToHash(nameof(Moving));

        private void FixedUpdate()
        {
            Vector3 movement = _input.GetMovementAxis();
            _animator.SetBool(Moving, movement != Vector3.zero);
            if (movement != Vector3.zero)
            {
                Quaternion rotGoal = Quaternion.LookRotation(movement);
                transform.rotation = Quaternion.Lerp(transform.rotation, rotGoal, _rotationLerp);
                _characterController.Move(movement);
            }
        }
    }
}