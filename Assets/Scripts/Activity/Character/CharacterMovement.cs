using Data;
using Infrastructure.Services;
using Services.Input;
using UnityEngine;

namespace Activity.Character
{
    public class CharacterMovement : MonoBehaviour, ISavedProgress
    {
        [SerializeField] private CharacterController characterController;
        [SerializeField] private float movementSpeed;

        private IInputService _inputService;
        private Camera _camera;

        private void Awake()
        {
            _inputService = AllServices.Container.GetSingle<IInputService>();
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
            characterController.Move(movementVector * (movementSpeed * Time.deltaTime));
        }

        public void LoadProgress(PlayerProgress playerProgress)
        {
            playerProgress.WorldData.Position = transform.position.AsVectorData();
        }

        public void UpdateProgress(PlayerProgress playerProgress)
        {
          
        }
    }
}
