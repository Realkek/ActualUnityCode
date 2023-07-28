using ForCamera;
using UnityEngine;

namespace Infrastructure
{
    public class LoadLevelState : IPayloadState<string>
    {
        private const string AnimeGirlPath = "Characters/AnimeGirl";
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter(string sceneName)
        {
            _sceneLoader.Load(sceneName, PrepareLevel);
        }

        private static void PrepareLevel()
        {
            var playerCharacter = Instantiate(AnimeGirlPath);
            Instantiate("SimpleInputDisplay");

            CameraFollow(playerCharacter);
        }

        private static GameObject Instantiate(string path)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab);
        }

        private static void CameraFollow(GameObject playerCharacter)
        {
            var camera = Camera.main;
            if (camera != null) camera.GetComponent<CameraFollow>().Follow(playerCharacter);
        }
        
        public void Exit()
        {
        }
    }
}