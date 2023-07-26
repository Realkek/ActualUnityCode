using System;
using Services.Input;
using UnityEngine;

namespace Infrastructure
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _gameStateMachine;

        public BootstrapState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            SetUpServices();
        }

        private void SetUpServices()
        {
            Game.InputService = InitializeInputService();
        }

        public void Exit()
        {
            
        }
        private static IInputService InitializeInputService()
        {
            if (Application.isEditor)
                return new DesktopInputService();
            return new MobileInputService();
        }
    }
}