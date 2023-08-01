using Infrastructure.AssetsManagement;
using Infrastructure.Factory;
using Infrastructure.Services;
using PersistentProgress;
using Services.Input;
using Services.SaveLoad;
using UnityEngine;

namespace Infrastructure.States
{
    public class BootstrapState : IState
    {
        private const string Initial = "Initial";
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
            _sceneLoader.Load(name: Initial, onLoaded: EnterLoadProgress);
        }

        private void EnterLoadProgress()
        {
            _gameStateMachine.Enter<LoadProgressState>();
        }

        private void SetUpServices()
        {
            _services.RegisterSingle(InitializeInputService());
            _services.RegisterSingle<IAssetsProvider>(new AssetsProvider());
            _services.RegisterSingle<IPersistentProgressService>(new PersistentProgressService());
            _services.RegisterSingle<ISaveLoadService>(new SaveLoadService());
            _services.RegisterSingle<IGameFactory>(new GameFactory(AllServices.Container.GetSingle<IAssetsProvider>()));
         
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