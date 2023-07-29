using UnityEngine;

namespace Infrastructure
{
    public class GameFactory : IGameFactory
    {
        private const string AnimeGirlPath = "Characters/AnimeGirl";
        private const string Simpleinputdisplay = "SimpleInputDisplay";
        public GameObject CreatePlayerCharacter(GameObject at)
        {
            var playerCharacter = Instantiate(path: AnimeGirlPath, at: at.transform.position);
            return playerCharacter;
        }

        public void CreateDisplay()
        {
            Instantiate(Simpleinputdisplay);
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
    }
}