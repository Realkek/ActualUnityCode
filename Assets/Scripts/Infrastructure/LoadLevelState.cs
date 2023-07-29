using Activity;
using ForCamera;
using UnityEngine;

namespace Infrastructure
{
    public class LoadLevelState : IPayloadState<string>
    {
       
        private const string Initialpoint = "InitialPoint";
       
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _loadingCurtain;
        private readonly IGameFactory _gameFactory;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, LoadingCurtain loadingCurtain)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
        }

        public void Enter(string sceneName)
        {
            _loadingCurtain.Show();
            _sceneLoader.Load(sceneName, PrepareLevel);
        }

        private void PrepareLevel()
        {
            var initialPoint = GameObject.FindWithTag(Initialpoint);
            var playerCharacter = _gameFactory.CreatePlayerCharacter(at: initialPoint);
            _gameFactory.CreateDisplay();

            CameraFollow(playerCharacter);
            _stateMachine.Enter<GameLoopState>();
        }

        private static void CameraFollow(GameObject playerCharacter)
        {
            var camera = Camera.main;
            if (camera != null) camera.GetComponent<CameraFollow>().Follow(playerCharacter);
        }
        
        public void Exit()
        {
            _loadingCurtain.Hide();
        }
    }
}