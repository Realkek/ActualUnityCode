using System;
using Services.Input;
using UnityEngine;

namespace Infrastructure
{
    public class BootstrapState : IState
    {
        private const string Initial = "Initial";
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader; 

        public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            SetUpServices();
            _sceneLoader.Load(Initial, onLoaded: EnterLoadLevel);
        }

        private void EnterLoadLevel()
        {
            _gameStateMachine.Enter<LoadLevelState>();
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