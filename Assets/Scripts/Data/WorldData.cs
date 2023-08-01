using System;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class WorldData
    {
        
        public PositionOnLevel PositionOnLevel { get; set; }
        
        public  WorldData(string initialLevel)
        {
            PositionOnLevel = new PositionOnLevel(initialLevel);
        }
    }
}