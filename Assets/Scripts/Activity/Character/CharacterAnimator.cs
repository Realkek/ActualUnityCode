using System;
using Infrastructure;
using Infrastructure.Services;
using Services.Input;
using UnityEngine;
using UnityEngine.Serialization;

namespace Character
{
    public class CharacterAnimator : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private CharacterController characterController;

        private static readonly int RunningHash = Animator.StringToHash("Running");
        private static readonly int IdleHash = Animator.StringToHash("Idle");
        private readonly int _walkingStateHash = Animator.StringToHash("Run");
        private IInputService _inputService;

        private void Awake()
        {
            _inputService = AllServices.Container.GetSingle<IInputService>();
        }

        private void Update()
        {
            if (_inputService.Axis.sqrMagnitude > Constants.Epsilon)
            {
                animator.SetFloat(RunningHash, characterController.velocity.magnitude, 0.01f, Time.deltaTime);
                animator.SetBool(IdleHash, false);
            }
            else
            {
                animator.SetFloat(RunningHash, 0);
                animator.SetBool(IdleHash, true);
            }
        }
    }
}