using System;

namespace ECSShooter.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public WorldData WorldData;

        public PlayerProgress(string levelName)
        {
            WorldData = new WorldData(levelName);
        }
    }
}