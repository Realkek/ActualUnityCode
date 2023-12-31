﻿using Infrastructure.Services;
using UnityEngine;

namespace Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreatePlayerCharacter(GameObject at);
        void CreateDisplay();
    }
}