using UnityEngine;

namespace Infrastructure
{
    public interface IGameFactory
    {
        GameObject CreatePlayerCharacter(GameObject at);
        void CreateDisplay();
    }
}