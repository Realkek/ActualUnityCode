using Activity;
using ForCamera;
using UnityEngine;

namespace Infrastructure
{
    public class LoadLevelState : IPayloadState<string>
    {
        private const string AnimeGirlPath = "Characters/AnimeGirl";
        private const string Initialpoint = "InitialPoint";
        private const string Simpleinputdisplay = "SimpleInputDisplay";
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _loadingCurtain;

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
            var playerCharacter = Instantiate(path: AnimeGirlPath, at: initialPoint.transform.position);
            Instantiate(Simpleinputdisplay);

            CameraFollow(playerCharacter);
            _stateMachine.Enter<GameLoopState>();
        }

        private static GameObject Instantiate(string path)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab);
        }
        private static GameObject Instantiate(string path, Vector3 at)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab, at, Quaternion.identity);
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