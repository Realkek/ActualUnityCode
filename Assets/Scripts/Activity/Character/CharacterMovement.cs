using ForCamera;
using Infrastructure;
using Services.Input;
using UnityEngine;

namespace Character
{
    public class CharacterMovement : MonoBehaviour
    {
        public CharacterController CharacterController;
        public float MovementSpeed;

        private IInputService _inputService;
        private Camera _camera;

        private void Awake()
        {
            _inputService = Game.InputService;
            _camera = Camera.main;
        }
        
        private void Update()
        {
            Vector3 movementVector = Vector3.zero;
            if (_inputService.Axis.sqrMagnitude > Constants.Epsilon)
            {
                movementVector = _camera.transform.TransformDirection(_inputService.Axis);
                movementVector.y = 0; 
                movementVector.Normalize();

                transform.forward = movementVector; 
            }
            movementVector += Physics.gravity;
            CharacterController.Move(movementVector * (MovementSpeed * Time.deltaTime));
        }
        
    }
}
