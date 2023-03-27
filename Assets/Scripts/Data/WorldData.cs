using System;

namespace ECSShooter.Data
{
    [Serializable]
    public class WorldData
    {
        public PositionOnLevel PositionOnLevel;

        public WorldData(string levelName)
        {
            PositionOnLevel = new PositionOnLevel(levelName);
        }
    }
}