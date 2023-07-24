using System;
using Infrastracture;
using Services.Input;
using UnityEngine;

namespace Character
{
    public class CharacterAnimator : MonoBehaviour
    {
        private static readonly int RunningHash = Animator.StringToHash("Running");
        private static readonly int IdleHash = Animator.StringToHash("Idle");
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
            {
                Animator.SetFloat(RunningHash, CharacterController.velocity.magnitude, 0.01f, Time.deltaTime);
                Animator.SetBool(IdleHash, false);
            }
            else
            {
                Animator.SetFloat(RunningHash, 0);
                Animator.SetBool(IdleHash, true);
            }
        }
        
    }
}