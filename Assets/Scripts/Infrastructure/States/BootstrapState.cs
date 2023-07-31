using Infrastructure.AssetsManagement;
using Infrastructure.Factory;
using Infrastructure.Services;
using PersistentProgress;
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
        private AllServices _services;

        public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, AllServices services)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _services = services;
            SetUpServices();
        }

        public void Enter()
        {
            
            _sceneLoader.Load(name: Initial, onLoaded: EnterLoadLevel);
        }

        private void EnterLoadLevel()
        {
            _gameStateMachine.Enter<LoadLevelState, string>(Gameplay);
        }

        private void SetUpServices()
        {
            _services.RegisterSingle(InitializeInputService());
            _services.RegisterSingle<IAssetsProvider>(new AssetsProvider());
            _services.RegisterSingle<IGameFactory>(new GameFactory(AllServices.Container.GetSingle<IAssetsProvider>()));
            _services.RegisterSingle<IPersistentProgressService>(new PersistentProgressService());
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