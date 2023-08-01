using System;

namespace Data
{
    [Serializable]
    public class PlayerProgress
    {
        public WorldData WorldData { get; set; }

        public PlayerProgress(string initialLevel)
        {
            
        }
    }
}