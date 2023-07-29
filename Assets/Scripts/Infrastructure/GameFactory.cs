using Infrastructure.AssetsManagement;
using UnityEngine;

namespace Infrastructure
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetsProvider _assetsProvider;
        
        public GameFactory(IAssetsProvider assetsProvider)
        {
            _assetsProvider = assetsProvider;
        }
        public GameObject CreatePlayerCharacter(GameObject at)
        {
            var playerCharacter = _assetsProvider.Instantiate(path: AssetsPaths.AnimeGirlPath, at: at.transform.position);
            return playerCharacter;
        }

        public void CreateDisplay()
        {
            _assetsProvider.Instantiate(AssetsPaths.Simpleinputdisplay);
        }

       
    }
}