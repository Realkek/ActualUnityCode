using Infrastructure.AssetsManagement;
using Infrastructure.Factory;
using Infrastructure.Services;
using Services.Input;
using UnityEngine;

namespace Infrastructure.States
{
    public class BootstrapState : IState
    {
        private const string Initial = "Initial";
        private const string Gameplay = "Gameplay";
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
            _sceneLoader.Load(name: Initial, onLoaded: EnterLoadLevel);
        }

        private void EnterLoadLevel()
        {
            _gameStateMachine.Enter<LoadLevelState, string>(Gameplay);
        }

        private void SetUpServices()
        {
            Game.InputService = InitializeInputService();
            AllServices.Container.RegisterSingle<IInputService>(InitializeInputService());
            AllServices.Container.RegisterSingle<IGameFactory>(new GameFactory(AllServices.GetSingle<IAssetsProvider>()));
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