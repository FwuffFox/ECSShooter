using UnityEngine;

namespace ECSShooter.Services.Input
{
    public class InputService
    {
        private readonly PlayerInput _playerInput = new();

        public InputService()
        {
            _playerInput.InGame.Enable();
        }

        public Vector3 GetMovementAxis()
        {
            Vector2 readValue = _playerInput.InGame.Movement.ReadValue<Vector2>();
            return new Vector3(readValue.x, 0, readValue.y);
        }
    }
}