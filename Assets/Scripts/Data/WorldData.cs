using System;

namespace ECSShooter.Data
{
    [Serializable]
    public class WorldData
    {
        public PositionOnLevel PositionOnLevel;
    }

    public class PositionOnLevel
    {
        public string Level;
        public Vector3Data Position;
        
        public PositionOnLevel(string level, Vector3Data position)
        {
            Level = level;
            Position = position;
        }
    }
}