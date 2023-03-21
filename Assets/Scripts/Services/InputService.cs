using UnityEngine;

namespace ECSShooter.Services
{
    public class InputService
    {
        private PlayerInput PlayerInput { get; } = new PlayerInput();
        
        public InputService()
        {
            PlayerInput.InGame.Enable();
        }
        
        public Vector2 GetMovement() => PlayerInput.InGame.Movement.ReadValue<Vector2>();
    }
}