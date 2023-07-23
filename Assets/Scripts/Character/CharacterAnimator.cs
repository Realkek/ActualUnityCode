using System;
using Infrastracture;
using Services.Input;
using UnityEngine;

namespace Character
{
    public class CharacterAnimator : MonoBehaviour
    {
        private static readonly int RunningHash = Animator.StringToHash("Running");
        private readonly int _walkingStateHash = Animator.StringToHash("Run");
        private InputService _inputService;
        public Animator Animator;
        public CharacterController CharacterController;

        private void Awake()
        {
            _inputService = Game.InputService;
        }

        private void Update()
        {
            if (_inputService.Axis.sqrMagnitude > Constants.Epsilon)
                Animator.SetFloat(RunningHash, CharacterController.velocity.magnitude, 0.1f, Time.deltaTime);
            else
            {
                Animator.SetFloat(RunningHash, 0f, 0.1f, Time.deltaTime);
            }
        }
    }
}