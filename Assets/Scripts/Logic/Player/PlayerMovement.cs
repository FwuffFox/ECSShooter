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
        [SerializeField] private float _speed;

        [Inject] private InputService _input;
        private static readonly int Moving = Animator.StringToHash(nameof(Moving));
        private static readonly int Running = Animator.StringToHash(nameof(Running));

        private void FixedUpdate()
        {
            Vector3 movement = _input.GetMovementAxis();
            _animator.SetBool(Moving, movement != Vector3.zero);
            if (movement == Vector3.zero)
            {
                _characterController.SimpleMove(Vector3.zero);
                return;
            }
            
            Quaternion rotGoal = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotGoal, _rotationLerp);
            float speed = _input.IsRunButtonPressed() ? _speed * 2 : _speed;
            _animator.SetBool(Running, _input.IsRunButtonPressed());
            _characterController.SimpleMove(movement * speed);
        }
    }
}