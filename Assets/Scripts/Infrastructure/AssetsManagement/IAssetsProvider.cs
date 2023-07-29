using UnityEngine;

namespace Infrastructure.AssetsManagement
{
    public interface IAssetsProvider
    {
        public  GameObject Instantiate(string path);
        public GameObject Instantiate(string path, Vector3 at);
    }
}